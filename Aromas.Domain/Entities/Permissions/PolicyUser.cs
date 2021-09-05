using System;
using System.Collections.Generic;
using System.Text;

namespace Aromas.Domain.Entities.Permissions
{
    public class PolicyUser
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PolicyId { get; set; }

        public virtual User User { get; set; }
        public virtual Policy Policy { get; set; }
    }
}
