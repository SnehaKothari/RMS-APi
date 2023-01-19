using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using recruitmentmanagementsystem.CommonMethods;
using recruitmentmanagementsystem.CommonModel;
using System.Threading.Tasks;

namespace recruitmentmanagementsystem.AccountRepository
{
    public interface IAccountrepository
    {
        Task<IdentityResult> SignUpAsync(LoginFields fields);
        Task<AuthResult> loginAsync(SignInmodel sigin);
    }
}
