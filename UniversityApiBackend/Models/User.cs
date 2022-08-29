using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using UniversityApiBackend.Models.DataModels;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace UniversityApiBackend.Models
{
    public class User : BaseEntity
    {
        [Required, StringLength(50)]
        public string Name { get; set; } = String.Empty;

        [Required, StringLength(50)]
        public string LastName { get; set; } = String.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = String.Empty;
        [Required]
        public string Password { get; set; } = String.Empty;

    }
}
