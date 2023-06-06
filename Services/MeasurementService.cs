using Entites;
using Medication;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MeasurementService : IMeasurementService
    {

        private IMeasurementRepository _measurementRepository;

        public MeasurementService(IMeasurementRepository measurementRepository)
        {
            _measurementRepository = measurementRepository;
        }
        public async Task<IEnumerable<Measurement>> getMeasurementsByDate(int userId, DateTime start, DateTime end)
        {
            return await _measurementRepository.getMeasurementsByDate(userId, start, end);
        }
        public async Task<Measurement> getLastMeasurement(int userId)
        {
            return await _measurementRepository.getLastMeasurement(userId);
        }
        public async Task<Measurement> addMeasurement(Measurement measurementForAdd)
        {
            return await _measurementRepository.addMeasurement(measurementForAdd);
        }

        Task<IEnumerable<Measurement>> IMeasurementService.getLastMeasurement(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
