using System.ComponentModel.DataAnnotations;

namespace Hahn.ApplicatonProcess.July2021.Web.DTOs.Users
{
    public class UpdateUserRequest
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(125)]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }
    }
}
