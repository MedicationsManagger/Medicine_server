using System;
using System.Collections.Generic;

namespace Entites
{
    public partial class Medicine
    {
        public Medicine()
        {
            MedicineForUsers = new HashSet<MedicineForUser>();
            MedicineStocks = new HashSet<MedicineStock>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<MedicineForUser> MedicineForUsers { get; set; }
        public virtual ICollection<MedicineStock> MedicineStocks { get; set; }
    }
}
