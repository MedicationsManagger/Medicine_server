using Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TakingMedicationDTO
    {
   
            public int Id { get; set; }
            public int MedicineForUserId { get; set; }
            public DateTime TimeOfTakingMedicine { get; set; }

        
        }
    }

