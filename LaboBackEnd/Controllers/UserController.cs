using LaboBLL.ServicesBLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult UserCreating()
        {
            return Ok();
        }

    }
}
