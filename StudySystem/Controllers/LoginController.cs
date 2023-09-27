﻿using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using MimeKit.Text;
using StudySystem.Application.Service.Interfaces;
using StudySystem.Data.EF;
using StudySystem.Data.Entites;
using StudySystem.Data.Models.Data;
using StudySystem.Data.Models.Request;
using StudySystem.Data.Models.Response;
using StudySystem.Infrastructure.CommonConstant;
using StudySystem.Infrastructure.Configuration;
using StudySystem.Infrastructure.Resources;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace StudySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userRegisterService;
        private readonly IUserTokenService _userTokenService;
        private readonly ILogger<LoginController> _logger;
        private readonly string _user;
        public LoginController(IUserService userRegisterService, IUserTokenService userTokenService, ILogger<LoginController> logger, UserResoveSerive user)
        {
            _userRegisterService = userRegisterService;
            _userTokenService = userTokenService;
            _logger = logger;
            _user = user.GetUser();
        }
        /// <summary>
        /// RegisterUser
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost(Router.RegisterUser)]
        public async Task<ActionResult<StudySystemAPIResponse<object>>> RegisterUser([FromBody] UserRegisterRequestModel request)
        {
            var result = await _userRegisterService.RegisterUserDetail(request);
            return new StudySystemAPIResponse<object>(StatusCodes.Status200OK, new Response<object>(result, new object()));
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="BadHttpRequestException"></exception>
        [HttpPost(Router.LoginUser)]
        public async Task<ActionResult<StudySystemAPIResponse<LoginResponseModel>>> Login([FromBody] LoginRequestModel request)
        {
            var user = await _userRegisterService.DoLogin(request);
            if (user != null)
            {
                if (await _userTokenService.IsUserOnl(user.UserID).ConfigureAwait(false))
                {
                    _logger.LogInformation("User Onl");
                    throw new BadHttpRequestException(Message.UserLogined);
                }
                var expireTime = DateTime.UtcNow.AddHours(AppSetting.JwtExpireTime);
                var expireTimeOnl = DateTime.UtcNow.AddMinutes(2);
                var claimUser = CeateClaim(user.UserID, user.UserFullName);
                var token = GenerateJwtToken(claimUser, expireTime);
                // delete user in UserToken
                await _userTokenService.Delete(user.UserID).ConfigureAwait(false);
                _logger.LogInformation($"Delete {user.UserID} from table UserToken");
                // insert user to table usertoken
                await _userTokenService.Insert(new Data.Entites.UserToken { UserID = user.UserID, Token = token,IsActive = user.IsActive, ExpireTime = expireTime, ExpireTimeOnline = expireTimeOnl }).ConfigureAwait(false);
                _logger.LogInformation($"Insert {user.UserID} from table UserToken");
                var userInfor = CreateUserInformation(user);

                return new StudySystemAPIResponse<LoginResponseModel>(StatusCodes.Status200OK, new Response<LoginResponseModel>(true, new LoginResponseModel(user.IsActive, token + "." + userInfor)));
            }
            _logger.LogInformation("Fail");
            throw new BadHttpRequestException(Message.InValidAccount);
        }
        /// <summary>
        /// Logout
        /// </summary>
        /// <returns></returns>
        [HttpPost(Router.LogOut)]
        [Authorize]
        public async Task<ActionResult<StudySystemAPIResponse<object>>> Logout()
        {
            await _userTokenService.Delete(_user).ConfigureAwait(false);
            _logger.LogInformation(Message.Logout);
            return new StudySystemAPIResponse<object>(StatusCodes.Status200OK, new Response<object>(true, data: Message.Logout));
        }

        private string CreateUserInformation(UserDetail user)
        {
            var userInfor = new UserInformationDataModel(user.UserID, user.UserFullName);
            var jsonString = JsonSerializer.Serialize(userInfor);
            var textBytes = Encoding.UTF8.GetBytes(jsonString);
            return Convert.ToBase64String(textBytes);
        }

        private Claim[] CeateClaim(string userID = "", string userName = "")
        {
            var claims = new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, AppSetting.JwtSub),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.AddHours(8).ToString()),
                    new Claim("UserID", userID),
                    new Claim("UserName", userName),
                };
            return claims;
        }

        private string GenerateJwtToken(Claim[] claims, DateTime expireTime)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(AppSetting.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = expireTime,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = AppSetting.Issuer,
                Audience = AppSetting.Audience,
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
