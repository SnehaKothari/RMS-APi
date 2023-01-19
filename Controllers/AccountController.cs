using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using recruitmentmanagementsystem.AccountRepository;
using recruitmentmanagementsystem.AuthecticationService;
using recruitmentmanagementsystem.CommonMethods;
using recruitmentmanagementsystem.CommonModel;
using System.Threading.Tasks;

namespace recruitmentmanagementsystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public ICandidateService _service;
        public AccountController(ICandidateService service)
        {
            _service=service;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(LoginFields fields)
        {
            var result = await _service.SignUpAsync(fields);

            if(result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
             return Unauthorized(); 

        }

        [HttpPost("login")]
        public async Task<AuthResult> login(SignInmodel sigin)
        {
            var result = await _service.loginAsync(sigin);

            return result;  
        }

    

       
        
    }
}
