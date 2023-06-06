using System;
using System.Collections.Generic;

namespace Entites
{
    public partial class MedicineForUser
    {
        public MedicineForUser()
        {
            TakingMedications = new HashSet<TakingMedication>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int MedicineId { get; set; }
        public double SumOfPills { get; set; }
        public int Hour { get; set; }
        public string? Note { get; set; }
        public bool Status { get; set; }

        public virtual Medicine Medicine { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<TakingMedication> TakingMedications { get; set; }
    }
}
