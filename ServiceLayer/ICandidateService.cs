using Microsoft.AspNetCore.Identity;
using recruitmentmanagementsystem.CommonMethods;
using recruitmentmanagementsystem.CommonModel;
using System.Threading.Tasks;

namespace recruitmentmanagementsystem.AuthecticationService
{
    public interface ICandidateService
    {
        Task<IdentityResult> SignUpAsync(LoginFields fields);
        Task<AuthResult> loginAsync(SignInmodel sigin);

    }
}
