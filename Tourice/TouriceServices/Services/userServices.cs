
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TouriceDatabases;
using TouriceDatabases.Modals;
using TouriceServices.IServices;

namespace TouriceServices.Services
{
    public class userServices: IUserServices
    {
        private readonly TouriceDatabaseContext _context;
        private IMapper _mapper;
        private IConfiguration _configuration;
        public userServices(TouriceDatabaseContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

      public string Login(tblUser user)
        {
            try
            {
            
                tblUser validUser = new tblUser();
                validUser = _context.user.Where(x=>x.UserName == user.UserName && x.Password == user.Password).FirstOrDefault();
                if (validUser != null)
                {

                 

                    var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, validUser.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Role, validUser.Role)
                };



                    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                    var token = new JwtSecurityToken(
                        issuer: _configuration["JWT:ValidIssuer"],
                        audience: _configuration["JWT:ValidAudience"],
                        expires: DateTime.Now.AddHours(3),
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                        );

                        string tokenstring = new JwtSecurityTokenHandler().WriteToken(token);
                    return validUser.Role+"."+  tokenstring;
                }

                else
                {
                    return "User Not Found";
                }

            }catch(Exception ex)
            {
                return ex.ToString();
            }
        }

    public async Task<string> SignUpUser(tblUser user)
        {
            try
            {
                await _context.AddAsync(user);
                var result = await _context.SaveChangesAsync();
                return "User Added Successfully";
            }catch(Exception ex)
            {
                throw;
            }
        }
    }
}
