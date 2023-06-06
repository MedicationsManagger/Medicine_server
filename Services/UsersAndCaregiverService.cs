using Entites;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UsersAndCaregiverService : IUsersAndCaregiverService

    {
        private IUsersAndCaregiverRepository _usersAndCaregiverRepository;
        public UsersAndCaregiverService(IUsersAndCaregiverRepository usersAndCaregiverRepository)
        {
            _usersAndCaregiverRepository = usersAndCaregiverRepository;
        }
    
        public async Task<UserAndCaregiver> addCaregiver(UserAndCaregiver caregiver)
        {
            return await _usersAndCaregiverRepository.addCaregiver(caregiver);
        }

        public async Task<IEnumerable<UserAndCaregiver>> getCaregiver(int userId)
        {
            return await _usersAndCaregiverRepository.getCaregiver(userId);
        }

        public async Task update(UserAndCaregiver caregiver)
        {
            await _usersAndCaregiverRepository.update(caregiver);
        }
    }
}
