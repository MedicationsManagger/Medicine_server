using Entites;
using Medication;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UsersAndCaregiverRepository : IUsersAndCaregiverRepository
    {
        MedicationsContext _medicationsContext;
        public UsersAndCaregiverRepository(MedicationsContext medicationsContext)
        {
            _medicationsContext = medicationsContext;
        }
        public async Task<UserAndCaregiver> addCaregiver(UserAndCaregiver caregiver)
        {
            await _medicationsContext.AddAsync(caregiver);
            await _medicationsContext.SaveChangesAsync();
            return caregiver;
        }

        public async Task<IEnumerable<UserAndCaregiver>> getCaregiver(int userId)
        {

            var uac = (from u in _medicationsContext.UserAndCaregivers
                       where u.UserId == userId
                       select u);

            List<UserAndCaregiver> userAndCaregiver = await uac.ToListAsync();
            return userAndCaregiver;

        }
        

        public async Task update(UserAndCaregiver caregiver)
        {
            var uToUpdate = await _medicationsContext.UserAndCaregivers.FindAsync(caregiver.Id);
            if (uToUpdate == null)
            {
                return;
            }
            _medicationsContext.Entry(uToUpdate).CurrentValues.SetValues(caregiver);
            await _medicationsContext.SaveChangesAsync();
            return;
        }
    }
}
