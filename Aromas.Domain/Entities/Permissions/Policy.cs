using Aromas.Domain.Entities.Permissions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aromas.Domain.Entities
{
    public class Policy
    {
        public Policy()
        {
            PolicyUser = new HashSet<PolicyUser>();
            PolicyMenu = new HashSet<PolicyMenu>();
        }

        public int Id { get; set; }
        public int Name { get; set; }
        public bool Active { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<PolicyUser> PolicyUser { get; set; }
        public virtual ICollection<PolicyMenu> PolicyMenu { get; set; }
    }
}
