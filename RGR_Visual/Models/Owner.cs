using System;
using System.Collections.Generic;

namespace RGR_Visual.Models
{
    public partial class Owner
    {
        public Owner()
        {
            Horses = new HashSet<Horse>();
            Name = "";
        }

        public string Name { get; set; } = null!;

        public virtual ICollection<Horse> Horses { get; set; }
    }
}
