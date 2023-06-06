using DTO;
using Entites;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public  class MedicineStockService : IMedicineStockService
    {
        private IMedicineStockRepository _medicineStockRepository;
        public MedicineStockService(IMedicineStockRepository medicineRepository)
        {
            _medicineStockRepository = medicineRepository;
        }
        public async Task<MedicineStock> AddMedicineStock(MedicineStock ms)
        {
            return await _medicineStockRepository.AddMedicineStock(ms);
        }

        public async Task<IEnumerable<MedicineStock>> GetMedicineStocks(int userId)
        {
            return await _medicineStockRepository.GetMedicineStocks(userId);
        }

        public async Task UpdateMedicineStock(MedicineStock ms)
        {
             await _medicineStockRepository.UpdateMedicineStock(ms);
        }

       
    }
}
