using DTO;
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
    public class MedicineForUserRepository : IMedicineForUserRepository
    {
        MedicationsContext _medicationsContext;
        public MedicineForUserRepository(MedicationsContext medicationsContext)
        {
            _medicationsContext = medicationsContext;
        }

        public async Task<IEnumerable<MedicineForUserDTO>> getMedicineForUser(int userId)
        {
            var query = (from mf in _medicationsContext.MedicineForUsers
                         join m in _medicationsContext.Medicines on mf.MedicineId equals m.Id into mj
                         from medicine in mj.DefaultIfEmpty()
                         where mf.UserId == userId
                         select new MedicineForUserDTO
                         {
                           Id=  mf.Id,
                           UserId=  mf.UserId,
                           MedicineId= mf.MedicineId,
                           Name = medicine.Name,
                           SumOfPills=mf.SumOfPills,
                           Hour=mf.Hour,
                           Note=mf.Note,
                           Status=mf.Status
                         });


            List<MedicineForUserDTO> medicineList = await query.ToListAsync();
            return medicineList;


            //var res = (from m in _medicationsContext.MedicineForUsers
            //           where m.UserId == userId
            //           select m);
            //List<MedicineForUser> medicineList = await res.ToListAsync();
            //return medicineList;

        }

        public async Task<MedicineForUser> addMedicineForUser(MedicineForUser medicineForUser)
        {
            await _medicationsContext.MedicineForUsers.AddAsync(medicineForUser);
            await _medicationsContext.SaveChangesAsync();
            return medicineForUser;
        }

        public async Task updateMedicineForUser(MedicineForUser medicineForUser)
        {
            var medicineToUpdate = await _medicationsContext.MedicineForUsers.FindAsync(medicineForUser.Id);
            if (medicineToUpdate == null)
            {
                return;
            }
            _medicationsContext.Entry(medicineToUpdate).CurrentValues.SetValues(medicineForUser);
            await _medicationsContext.SaveChangesAsync();
            return;
        }


    }
}
