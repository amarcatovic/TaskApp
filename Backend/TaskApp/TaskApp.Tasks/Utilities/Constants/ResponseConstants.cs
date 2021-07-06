using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskApp.Tasks.Utilities.Constants
{
    public class ResponseConstants
    {
        public static string ERROR_GENERIC = "A server error happened";
        public static string ERROR_CREATING_TASK = "There was an error in creating a new task";
        public static string ERROR_EDITING_TASK = "There was an error in editing task";
        public static string NOT_FOUND_USER_TASKS = "This user does not have any tasks";
        public static string NOT_FOUND_USER_ASSIGNED_TASKS = "This user does not have any assigned tasks";
    }
}
