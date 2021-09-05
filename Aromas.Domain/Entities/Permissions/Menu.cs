using System;
using System.Collections.Generic;
using System.Text;

namespace Aromas.Domain.Entities
{
    public class Menu
    {
        public Menu()
        {
            PolicyMenu = new HashSet<PolicyMenu>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<PolicyMenu> PolicyMenu { get; set; }
    }
}
