using DTO;
using Entites;

namespace Repository
{
    public interface IMedicineForUserRepository
    {
        public Task<IEnumerable<MedicineForUserDTO>> getMedicineForUser(int userId);
        public Task<MedicineForUser> addMedicineForUser(MedicineForUser medicineForUser);
        public Task updateMedicineForUser(MedicineForUser medicineForUser);

 
    }
}