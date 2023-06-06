using System;
using System.Collections.Generic;

namespace Entites
{
    public partial class MedicineStock
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MedicineId { get; set; }
        public double PillsInStock { get; set; }

        public virtual Medicine Medicine { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
