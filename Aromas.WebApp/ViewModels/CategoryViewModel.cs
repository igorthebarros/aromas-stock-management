using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aromas.MVC.ViewModels
{
    public class CategoryViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please, enter a name.")]
        [MaxLength(100, ErrorMessage = "The maximum number of characters is {0}")]
        [MinLength(2, ErrorMessage = "The minimum number of characters is {0}")]
        public string Name { get; set; }
        public string SubCategory { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Active { get; set; }
        public virtual IEnumerable<ProductViewModel> Products { get; set; }
    }
}
