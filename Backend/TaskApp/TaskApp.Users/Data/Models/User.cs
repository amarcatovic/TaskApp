namespace TaskApp.Users.Data.Models
{
    public class User
    {
        /// <summary>
        /// User's Unique Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User's email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// User's first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// User's last name
        /// </summary>
        public string LastName { get; set; }
    }
}
