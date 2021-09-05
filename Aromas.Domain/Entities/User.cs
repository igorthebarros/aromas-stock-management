using Aromas.Domain.Entities.Permissions;
using System;
using System.Collections.Generic;

namespace Aromas.Domain.Entities
{
    public class User
    {
        public User()
        {
            PolicyUser = new HashSet<PolicyUser>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Email { get; set; }
        public int Password { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<PolicyUser> PolicyUser { get; set; }
    }
}
