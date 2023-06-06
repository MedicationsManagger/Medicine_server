using Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IUsersAndCaregiverRepository
    {
        public Task<IEnumerable<UserAndCaregiver>> getCaregiver(int userId);
        public Task<UserAndCaregiver> addCaregiver(UserAndCaregiver caregiver);
        public Task update(UserAndCaregiver caregiver);
    }
}
