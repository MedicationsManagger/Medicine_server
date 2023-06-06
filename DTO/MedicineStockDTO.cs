using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public  class MedicineStockDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MedicineId { get; set; }
        public double PillsInStock { get; set; }
    }
}
