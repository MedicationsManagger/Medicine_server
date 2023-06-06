using DTO;
using Entites;

namespace Services
{
    public interface IMedicineForUserService
    {
        public Task<IEnumerable<MedicineForUserDTO>> getMedicineForUser(int userId);
        public Task<MedicineForUser> addMedicineForUser(MedicineForUser medicineForUser);
        public Task updateMedicineForUser(MedicineForUser medicineForUser);

    }
}