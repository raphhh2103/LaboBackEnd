using DashBoardAPI.Services;
using LaboBackEnd.ModelsAPI;
using LaboBLL.ModelsBLL;
using LaboBLL.ServicesBLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LaboBackEnd.MapperAPI;

namespace LaboBackEnd.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase
    {
        private readonly UserSericeBLL _userServiceBLL;

        public UserController(UserSericeBLL userSericeBLL)
        {
            this._userServiceBLL = userSericeBLL;
        }

        [HttpPost]
        public IActionResult UserCreating(UserAPI user)
        {
            byte[] salt = Crypto.GenerateSalt();
            //= salt;
            UserBLL us = user.ToBLL();
            us.SaltKey = salt;
            us.Passwd = Crypto.AshPassword(salt, user.Passwd);
            _userServiceBLL.Create(us);
            return Ok();
        }

        [HttpGet("{Email}")]
        public IActionResult GetUser(string Email)
        {
            return Ok(_userServiceBLL.GetOne(Email).ToAPI());
        }

        [HttpPut("{Email}")]
        public IActionResult UpdateUser(string Email, [FromBody] UserAPI userModified)
        {
            UserBLL us = _userServiceBLL.GetOne(Email);

            if (us != null)
            {
                us.Email = userModified.Email;
                us.Rule = userModified.Rule;
                us.Passwd = Crypto.AshPassword(us.SaltKey, userModified.Passwd);
                //us.Passwd= userModified.Passwd;
                _userServiceBLL.Update(us);
            }



            return Ok(us.ToAPI());
        }

    }
}
