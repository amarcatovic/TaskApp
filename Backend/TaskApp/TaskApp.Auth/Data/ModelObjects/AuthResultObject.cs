using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskApp.Auth.Data.UserService;

namespace TaskApp.Auth.Data.ModelObjects
{
    public class AuthResultObject
    {
        public UserReadDto User { get; set; }

        public string Token { get; set; }
    }
}
