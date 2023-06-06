using Entites;

namespace Repository
{
    public interface IMedicineRepository
    {
        public Task< IEnumerable<Medicine> >getAllMedicines();
        public Task<Medicine>getMedicineById(int medicineId);
        public Task<Medicine> addMedicine(Medicine medicine);
        //public Task deleteMedicine(int medicineId);
    }
}