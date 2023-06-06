using Entites;
using Medication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{

    public class MedicineRepository : IMedicineRepository
    {
        private readonly MedicationsContext _medicationsContext;

        public MedicineRepository(MedicationsContext medicationsContext)
        {
            _medicationsContext = medicationsContext;
        }
        public async Task< IEnumerable<Medicine>> getAllMedicines()
        {
            var res = (from m in _medicationsContext.Medicines
                       select m).ToList();
            return res;
        }

        public async Task< Medicine> getMedicineById(int medicineId)
        {
            var res = (from m in _medicationsContext.Medicines
                       where m.Id == medicineId
                       select m);
           
            return res.FirstOrDefault(); 
        }
        public async Task<Medicine> addMedicine(Medicine medicine)
        {
            await _medicationsContext.Medicines.AddAsync(medicine);
            await _medicationsContext.SaveChangesAsync();
            return medicine;
        }

        //public async Task deleteMedicine(int medicineId)
        //{
        //    //מה התחביר של מחיקת פריט מאנטיטי פריימוורק?
        //    using (var context = _medicationsContext)
        //    {
        //        var medicineToDelete = await context.Medicines.FindAsync(medicineId);
        //        if (medicineToDelete != null)
        //        {
        //            context.Medicines.Remove(medicineToDelete); 
        //            await context.SaveChangesAsync();
        //        }

        //    }
        //}

        
    }
}
