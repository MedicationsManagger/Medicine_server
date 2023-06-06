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
    public class TakingMedicationRepository : ITakingMedicationRepository
    {

        MedicationsContext _medicationsContext;
        public TakingMedicationRepository(MedicationsContext medicationsContext)
        {
            _medicationsContext = medicationsContext;
        }
        public async Task<TakingMedication> addTakingMedication(TakingMedication takingMedication)
        {
            await _medicationsContext.TakingMedications.AddAsync(takingMedication);
            await _medicationsContext.SaveChangesAsync();
            return takingMedication;

        }

        public async Task<IEnumerable<TakingMedication>> getTakingMedication(int takeMId)
        {
            var res = (from t in _medicationsContext.TakingMedications
                       where t.MedicineForUser == takeMId
                       select t );
          //  List<SystemMessage> takingMedicationList = await res.ToListAsync();
            return res;
        }

    }
}
