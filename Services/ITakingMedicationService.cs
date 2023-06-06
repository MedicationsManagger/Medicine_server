using Entites;

namespace Services
{
    public interface ITakingMedicationService
    {
        public Task<IEnumerable<TakingMedication>> getTakingMedication(int takeMId);
        public Task<TakingMedication> addTakingMedication(TakingMedication takingMedication);

  

    }
}