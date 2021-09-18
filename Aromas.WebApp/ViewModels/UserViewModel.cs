using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aromas.MVC.ViewModels
{
    public class UserViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please, enter a name.")]
        [MaxLength(100, ErrorMessage = "The maximum number of characters is {0}")]
        [MinLength(2, ErrorMessage = "The minimum number of characters is {0}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please, enter a surname.")]
        [MaxLength(100, ErrorMessage = "The maximum number of characters is {0}")]
        [MinLength(2, ErrorMessage = "The minimum number of characters is {0}")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Please, enter an email.")]
        [MaxLength(100, ErrorMessage = "The maximum number of characters is {0}")]
        [EmailAddress(ErrorMessage = "Please, enter a valid e-mail")]
        [DisplayName("E-mail")]
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
