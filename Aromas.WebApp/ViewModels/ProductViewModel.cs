using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Aromas.Domain.Entities;

namespace Aromas.MVC.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please, enter a name.")]
        [MaxLength(100, ErrorMessage = "The maximum number of characters is {0}")]
        [MinLength(2, ErrorMessage = "The minimum number of characters is {0}")]
        public string Name { get; set; }
        public bool IsInStock { get; set; }
        public int StockQuantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
