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
    public class MedicineForUserService : IMedicineForUserService
    {
        private IMedicineForUserRepository _medicineForUserRepository;

        public MedicineForUserService(IMedicineForUserRepository medicineForUserRepository)
        {
            _medicineForUserRepository = medicineForUserRepository;
        }

        public async Task<IEnumerable<MedicineForUserDTO>> getMedicineForUser(int userId)
        {
            return await _medicineForUserRepository.getMedicineForUser(userId);
        }

        public async Task<MedicineForUser> addMedicineForUser(MedicineForUser medicineForUser)
        {
            return await _medicineForUserRepository.addMedicineForUser(medicineForUser);
        }

        public async Task updateMedicineForUser(MedicineForUser medicineForUser)
        {
            await _medicineForUserRepository.updateMedicineForUser(medicineForUser);
        }
    }
}
