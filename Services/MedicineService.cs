using Entites;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MedicineService : IMedicineService
    {
        private IMedicineRepository _medicineRepositroy;

        public MedicineService(IMedicineRepository medicineRepositroy)
        {
            _medicineRepositroy = medicineRepositroy;
        }

        public async Task<IEnumerable<Medicine>> getAllMedicines()
        {
            return await _medicineRepositroy.getAllMedicines();
        }

        public async Task<Medicine> getMedicineById(int medicineId)
        {
            return await _medicineRepositroy.getMedicineById(medicineId);
        }

        public async Task<Medicine> addMedicine(Medicine medicine)
        {
            return await _medicineRepositroy.addMedicine(medicine);
        }

        //public async Task deleteMedicine(int medicineId)
        //{
        //    await _medicineRepositroy.deleteMedicine(medicineId);
        //}
    }
}