using DashBoardAPI.Services;
using JwtBehavior.Auth;
using LaboBackEnd.MapperAPI;
using LaboBackEnd.ModelsAPI;
using LaboBackEnd.ServiceAPI;
using LaboBLL.ModelsBLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using jwt = JwtBehavior.JwtHelpers;
namespace LaboBackEnd.Controllers
{
    [ApiController]
    [Route("Account")]
    public class AccountController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;
        private readonly AccountServiceAPI _accountService;

        public AccountController(JwtSettings jwtSettings , AccountServiceAPI accountService):base()
        {
            this._jwtSettings = jwtSettings;
            this._accountService = accountService;
        }
       
        [HttpPost]
        public IActionResult GetAuth (UserAPI userLogins)
        {
            UserBLL user = new UserBLL();
            string str = "";
            byte[] bytes = Crypto.GenerateSalt();

            user = _accountService.VerifyUser(userLogins);
            if (user != null)
            {
                //str = userLogins.Passwd;
                userLogins.Passwd = Crypto.AshPassword(user.SaltKey,userLogins.Passwd);
                if (userLogins.Passwd == user.Passwd)
                {
                    UserTokens token = new UserTokens();
                    UserAPI Account = _accountService.GetOwnerCredentials(userLogins.Email);
                    token = jwt.JwtHelpers.GenTokenKey(new UserTokens()
                    {
                        Id= Account.IdUser,
                        Email= Account.Email,
                        IsOwner = false
                    },_jwtSettings);
                return Ok( new { token = token.Token});
                }
                else
                {
                    return BadRequest(" password incorrect !");
                }
            }
            else
            {
                return BadRequest("error ");
            }
        }



    }
}
