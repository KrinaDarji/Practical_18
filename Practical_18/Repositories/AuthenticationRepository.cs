using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Practical_18.Contracts;
using Practical_18.Data;
using Practical_18.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Practical_18.Repositories
{
    public class AuthenticationRepository : GenericRepositories<UserVM>, IAuthenticationRepository
    {
      
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IConfiguration configuration;

        public AuthenticationRepository(ApplicationDBcontext context, UserManager<User> userManager,
        SignInManager<User> signInManager,IConfiguration configuration) : base(context)
        {
           
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }

        public async Task<IdentityResult> signUp(UserVM user)
        {
            var CurrentUser = new User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.Email,
            };
            return await userManager.CreateAsync(CurrentUser, user.Password);
        }
        public async Task<string> LogInAsync(SignInModel signInModel)
        {
            var result = await signInManager.PasswordSignInAsync(signInModel.Email,signInModel.Password,false,false);
            if (!result.Succeeded) {
                return null;
            }
            var authclaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, signInModel.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };
            var authsignkey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["JWT:secret"]));
            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["Jwt:ValidAudience"],
                expires: DateTime.Now.AddDays(1),
                claims: authclaims,
                signingCredentials: new SigningCredentials(authsignkey, SecurityAlgorithms.HmacSha256Signature)

                );
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
