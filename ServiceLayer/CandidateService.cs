
using Microsoft.AspNetCore.Identity;
using recruitmentmanagementsystem.AccountRepository;
using recruitmentmanagementsystem.CommonMethods;
using recruitmentmanagementsystem.CommonModel;
using System.Threading.Tasks;

namespace recruitmentmanagementsystem.AuthecticationService
{
    public class CandidateService : ICandidateService
    {

        private readonly IAccountrepository _repository;

        public CandidateService(IAccountrepository repository)
        {
            _repository = repository;
        }
      public   Task<IdentityResult> SignUpAsync(LoginFields fields)
        {
          return   _repository.SignUpAsync(fields);

            
        }
      public Task<AuthResult> loginAsync(SignInmodel sigin)
        {
          return   _repository.loginAsync(sigin);
        }
    }
}
