using Entites;

namespace Services
{
    public interface IMedicineService
    {
        public Task<IEnumerable<Medicine>> getAllMedicines();
        public Task<Medicine> getMedicineById(int medicineId);
        public Task<Medicine> addMedicine(Medicine medicine);
//      public Task deleteMedicine(int medicineId);
    }
}