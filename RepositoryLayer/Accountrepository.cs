using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using recruitmentmanagementsystem.CommonMethods;
using recruitmentmanagementsystem.CommonModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace recruitmentmanagementsystem.AccountRepository
{
    public class Accountrepository : IAccountrepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly SignInManager<ApplicationUser> _siginmanager;


        private readonly RoleManager<IdentityRole> _rolemanager;

        private readonly IConfiguration _configuration;
        public Accountrepository(UserManager<ApplicationUser> usermanager, SignInManager<ApplicationUser> siginmanager,
                                  RoleManager<IdentityRole> rolemanager,IConfiguration cofiguration)
        {
            _userManager = usermanager;
            _siginmanager = siginmanager;
            _configuration = cofiguration;
            _rolemanager=rolemanager;

        }

        public async Task<IdentityResult> SignUpAsync(LoginFields fields)
        {

            var user = new ApplicationUser()
            {
                Email = fields.email_id,
                usertype = fields.usertype,
                UserName = fields.email_id

            };

            System.Diagnostics.Debug.WriteLine(fields.usertype);

            await _userManager.CreateAsync(user, fields.password);
            await _userManager.AddToRoleAsync(user, fields.usertype);
            return IdentityResult.Success;
        }


        public async Task<AuthResult> loginAsync(SignInmodel signin)
        {
            //var result = await _siginmanager.PasswordSignInAsync(sigin.Email, sigin.Password, false, false);

            var existinguser = await _userManager.FindByEmailAsync(signin.Email);

            if (existinguser!=null)
            {
                var isCorrect = await _userManager.CheckPasswordAsync(existinguser, signin.Password);

                if (isCorrect)
                {
                    if (existinguser.usertype==signin.usertype)
                    {
                        var jwtToken = await GenerateJwtToken(existinguser);

                        // return jwtToken;

                        var res = new AuthResult()
                        {
                            role = signin.usertype,
                            Token = jwtToken.Token

                        };

                          return res;
                    }

                    else
                    {
                        return null;
                    }

                }
                else
                {
                    return null;
                }

               
            }
            else
            {
                return null;
            }

        }

        public async Task<AuthResult> GenerateJwtToken(ApplicationUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_configuration["jwt:Secret"]);

            var claims = await GetAllValidClaims(user);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                // Expires = DateTime.UtcNow.AddSeconds(30), // 5-10 
                Expires = DateTime.UtcNow.AddDays(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return new AuthResult()
            {
                Token = jwtToken,
              //  Success = true  
            };







        }

        private async Task<List<Claim>> GetAllValidClaims(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim("Id", user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            // Getting the claims that we have assigned to the user
            var userClaims = await _userManager.GetClaimsAsync(user);
            claims.AddRange(userClaims);

            // Get the user role and add it to the claims
            var userRoles = await _userManager.GetRolesAsync(user);

            foreach (var userRole in userRoles)
            {
                var role = await _rolemanager.FindByNameAsync(userRole);

                if (role != null)
                {
                    claims.Add(new Claim(ClaimTypes.Role, userRole));

                    var roleClaims = await _rolemanager.GetClaimsAsync(role);
                    foreach (var roleClaim in roleClaims)
                    {
                        claims.Add(roleClaim);
                    }
                }
            }

            return claims;
        }

    }

}
