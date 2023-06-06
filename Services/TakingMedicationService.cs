using Entites;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TakingMedicationService : ITakingMedicationService
    {

        private ITakingMedicationRepository _takingMedicationRepository;

        public TakingMedicationService(ITakingMedicationRepository takingMedicationRepository)
        {
            _takingMedicationRepository = takingMedicationRepository;
        }
        public async Task<TakingMedication> addTakingMedication(TakingMedication takingMedication)
        {
            return await _takingMedicationRepository.addTakingMedication(takingMedication); 
        }
        public async Task<IEnumerable<TakingMedication>> getTakingMedication(int takeMId)
        {
            return await _takingMedicationRepository.getTakingMedication(takeMId);
        }
    }
}
