using System;
using System.Collections.Generic;

namespace RGR_Visual.Models
{
    public partial class Horse : IEquatable<Horse>
    {
        public string? Name { get; set; } = null!;
        public string? Gender { get; set; }
        public long? Age { get; set; }
        public string? Weight { get; set; }
        public string? Trainer { get; set; }
        public string Owner { get; set; } = null!;

        public virtual Owner OwnerNavigation { get; set; } = null!;
        public virtual Trainer? TrainerNavigation { get; set; }

        public Horse()
        {
            Name = "";
            Gender = "";
            Age = 0;
            Weight = "";
            Trainer = "";
            Owner = "";
            OwnerNavigation = null!;
            TrainerNavigation = null;
        }

        public bool Equals(Horse? other)
        {
            return (this.Name == other.Name);
        }
    }
}
