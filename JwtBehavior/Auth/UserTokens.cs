using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtBehavior.Auth
{
    public class UserTokens
    {
        public string Token { get; set; }
        public bool IsOwner { get; set; }
        public string? Email { get; set; }
        public int Id { get; set; }
        public string Pseudo { get; set; }




    }
}
