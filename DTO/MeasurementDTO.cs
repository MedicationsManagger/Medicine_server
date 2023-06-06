using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MeasurementDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public double? Weight { get; set; }
        public double? Height { get; set; }
        public int? BloodPressure { get; set; }
        public int? Situration { get; set; }
        public int? Pulese { get; set; }
        public DateTime DateOfMeasure { get; set; }
    }
}
