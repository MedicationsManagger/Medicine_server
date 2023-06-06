using System;
using System.Collections.Generic;

namespace Entites
{
    public partial class TakingMedication
    {
        public int Id { get; set; }
        public int MedicineForUser { get; set; }
        public DateTime TimeOfTakingMedicine { get; set; }

        public virtual MedicineForUser MedicineForUserNavigation { get; set; } = null!;
    }
}
