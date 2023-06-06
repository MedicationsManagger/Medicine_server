using Entites;

namespace Repository
{
    public interface ITakingMedicationRepository
    {
        public Task<IEnumerable<TakingMedication>> getTakingMedication(int takeMId);
        public Task<TakingMedication> addTakingMedication(TakingMedication takingMedication);

    }
}