using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskApp.Notifications.Data.UserService
{
    public class UserReadDto
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhotoUrl { get; set; }

        public string Initials { get; set; }
    }
}
