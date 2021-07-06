using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TaskApp.Users.Utilities.Annotations
{
    public class PasswordAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            var password = value as string;

            if (password == null)
            {
                return false;
            }

            if (password.Length < 6)
            {
                return false;
            }

            if (!password.Any(char.IsUpper))
            {
                return false;
            }

            if (!password.Any(char.IsLower))
            {
                return false;
            }

            if (!password.Any(char.IsDigit))
            {
                return false;
            }

            return true;
        }
    }
}
