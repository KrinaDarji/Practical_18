using Microsoft.AspNetCore.Identity;
using Practical_18.Data;
using Practical_18.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical_18.Contracts
{
    public interface IAuthenticationRepository : IGenericRepository<UserVM>
    {
        Task<IdentityResult> signUp(UserVM user);
        Task<string> LogInAsync(SignInModel signInModel);
    }
}
