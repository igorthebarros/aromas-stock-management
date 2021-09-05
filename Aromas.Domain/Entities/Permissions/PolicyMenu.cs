using System;
using System.Collections.Generic;
using System.Text;

namespace Aromas.Domain.Entities
{
    public class PolicyMenu
    {
        public int Id { get; set; }
        public int PolicyId { get; set; }
        public int MenuId { get; set; }
        public bool Active { get; set; }

        public virtual Policy Policy { get; set; }
        public virtual Menu Menu { get; set; }
    }
}
