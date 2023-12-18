using System.ComponentModel.DataAnnotations;

namespace OA.Data
{
    public class UserModel
    {
        [Key]
        public int ID{ get; set; }
        [Required(ErrorMessage ="Name cannot be empty.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email cannot be empty.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
