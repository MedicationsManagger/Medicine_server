using Entites;
using Medication;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Repository
{
    public class MeasurementRepository : IMeasurementRepository
    {

        MedicationsContext _medicationsContext;
        public MeasurementRepository(MedicationsContext medicationsContext)
        {
            _medicationsContext = medicationsContext;
        }

        public async Task<Measurement> addMeasurement(Measurement measurementForAdd)
        {
            await _medicationsContext.Measurements.AddAsync(measurementForAdd);
            await _medicationsContext.SaveChangesAsync();
            return measurementForAdd;
        }

        //public async Task<IEnumerable<Measurement>> getLastMeasurement(int userId)
        //{
        //    Measurement lastMeasurement = await _medicationsContext.Measurements.Where((s) => s.UserId == userId)
        //        .OrderByDescending((x) => x.DateOfMeasure).FirstAsync();

        //    return lastMeasurement;


        //}

        public async Task<List<Measurement>> getMeasurementsByDate(int userId, DateTime start, DateTime end)
        {

            List<Measurement> lastMeasurement = await _medicationsContext.Measurements.Where(ms =>
                                         (ms.UserId == userId)
                                      && (ms.DateOfMeasure > start)
                                      && (ms.DateOfMeasure < end)).OrderBy(ms => ms.BloodPressure).ToListAsync();

            // List<Measurement> measurements = lastMeasurement;
            return lastMeasurement;

        }

        Task<Measurement> IMeasurementRepository.getLastMeasurement(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
