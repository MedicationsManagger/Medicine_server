using DTO;
using Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IMedicineStockService
    {
        public Task<IEnumerable<MedicineStock>> GetMedicineStocks(int userId);
        public Task<MedicineStock> AddMedicineStock(MedicineStock ms);
        public Task UpdateMedicineStock(MedicineStock ms);
    }
}

