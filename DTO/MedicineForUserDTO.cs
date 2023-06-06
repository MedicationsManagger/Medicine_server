using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MedicineForUserDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MedicineId { get; set; }
        public string Name { get; set; }
        public double SumOfPills { get; set; }
        public int Hour { get; set; }
        public string? Note { get; set; }
        public bool Status { get; set; }

    }
}
