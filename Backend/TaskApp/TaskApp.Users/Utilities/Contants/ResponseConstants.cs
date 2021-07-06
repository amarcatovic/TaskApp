using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskApp.Users.Utilities.Contants
{
    public static class ResponseConstants
    {
        public static string ERROR_GENERIC = "A server error happened";
        public static string ERROR_CREATING_USER = "There was an error in creating new user";
        public static string ERROR_NO_SPECIFIC_USER_FOUND_ID = "There was no user with given id";
        public static string ERROR_NO_SPECIFIC_USER_FOUND_EMAIL = "There was no user with given email";
    }
}
