using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Practical_18.Contracts;
using Practical_18.Data;
using Practical_18.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_18.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Authentication : ControllerBase
    {
        private readonly IAuthenticationRepository authenticationRepositories;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public Authentication(
        IAuthenticationRepository authenticationRepositories
        , IMapper mapper,
        UserManager<User> userManager,
        SignInManager<User> signInManager)
        {
            this.authenticationRepositories = authenticationRepositories;
            this.mapper = mapper;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpPost("signUp")]
        public async Task<IActionResult> OnsignPostAsync([FromBody] UserVM user)
        {
            var result = await authenticationRepositories.signUp(user);
            if (result.Succeeded)
            {
                return Ok();
            }
            return Unauthorized();
        }
        [HttpPost("Login")]
        public async Task<IActionResult> LogIn([FromBody] SignInModel signInModel)
        {
            var result = await authenticationRepositories.LogInAsync(signInModel);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }
            return Ok(result);
        }
    }
}
