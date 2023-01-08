using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FoodsOrderAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.IdentityModel.Tokens;

namespace FoodsOrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtController : ControllerBase
    {
        private IConfiguration _configuration;

        public JwtController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("CreateToken")]
        public ActionResult CreateToken(LoginModel loginModel)
        {
            if (loginModel != null && loginModel.Username != null && loginModel.Password != null)
            {
                var validUser = loginModel;
                if (validUser != null)
                {
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
                    var token = new JwtSecurityToken(
                        issuer: _configuration["Jwt:Issuer"],
                        audience: _configuration["Jwt:Audience"],
                        claims: new[] {
                            new Claim("Username", validUser.Username)
                        },
                            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                        );
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid Creadetials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

    }

}
