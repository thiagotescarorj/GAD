using AutoMapper;
using Impacta.GAD.Application.DTOs;
using Impacta.GAD.Application.Interfaces;
using Impacta.GAD.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Impacta.GAD.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration configuration,
                            UserManager<User> userManager,
                            IMapper mapper)
        {
            _configuration = configuration;
            _userManager = userManager;
            _mapper = mapper;
            //_Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["GBTKey"]));

            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]));
        }



        //public async Task<string> CreateToken(UserUpdateDTO userUpdateDTO)
        //{
        //    var user = _mapper.Map<User>(userUpdateDTO);
        //    var roles = _userManager.GetRolesAsync(user);


        //    var secretKey = "gbt-gda-secret-key this is my custom Secret key for authentication";
        //    var keyBytes = Encoding.UTF8.GetBytes(secretKey);
        //    var signingKey = new SymmetricSecurityKey(keyBytes);


        //    var claims = new[]
        //    {
        //    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), 
        //    new Claim(ClaimTypes.Email, user.Email),
        //};

        //    // Crie o token
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(claims),
        //        Expires = DateTime.UtcNow.AddDays(1),
        //        SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha512Signature)
        //    };

        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var token = tokenHandler.CreateToken(tokenDescriptor);

        //    // Retorne o token como uma string
        //    return await Task.FromResult(tokenHandler.WriteToken(token));
        //}

        public async Task<string> CreateToken(UserUpdateDTO userUpdateDto)
        {
            var user = _mapper.Map<User>(userUpdateDto);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email)
            };

            var roles = await _userManager.GetRolesAsync(user);

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescription);

            return tokenHandler.WriteToken(token);
        }


    }
}
