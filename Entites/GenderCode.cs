using System;
using System.Collections.Generic;

namespace Entites
{
    public partial class GenderCode
    {
        public GenderCode()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string GenderDescription { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
