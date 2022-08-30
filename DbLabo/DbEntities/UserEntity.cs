using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLabo.DbEntities
{
    public class UserEntity
    {
        public string Email { get; set; }

        public string Passwd { get; set; }

        public string Rule  { get; set; }

        public byte[] SaltKey { get; set; }

    }
}
