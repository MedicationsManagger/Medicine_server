using AutoMapper;
using DTO;
using Entites;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Medication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementController : ControllerBase
    {
        private readonly IMeasurementService _measurementService;
        private readonly IMapper _mapper;


        public MeasurementController(IMeasurementService measurementService, IMapper mapper)
        {
            _measurementService = measurementService;
            _mapper = mapper;
        }




        [HttpGet]
        public async Task<ActionResult<IEnumerable<MeasurementDTO>>> Get([FromQuery] int userId)
        {

            if (_measurementService.getLastMeasurement(userId) != null)
            {
                IEnumerable<Measurement> lastMesurment = await _measurementService.getLastMeasurement(userId);
                IEnumerable<MeasurementDTO> lastMesurmentDTO = _mapper.Map<IEnumerable<Measurement>, IEnumerable<MeasurementDTO>>(lastMesurment);
                return Ok(lastMesurmentDTO);
            }
            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult<Measurement>> Post([FromBody] MeasurementDTO measurement)
        {
            Measurement newMeasurement = _mapper.Map<MeasurementDTO, Measurement>(measurement);
            newMeasurement.User = null;
            Measurement ms = await _measurementService.addMeasurement(newMeasurement);
            return ms;

        }


        //[HttpGet]
        //public async Task<ActionResult<Measurement>> Get([FromQuery] int userId)
        //{
        //    IEnumerable<Measurement> lastMesurment = await _measurementService.getLastMeasurement(userId);
        //    if (lastMesurment == null)
        //    {
        //        return NoContent();
        //    }
        //    return Ok(lastMesurment);
        //}
    }
}
        //[HttpGet("{id}")]
        //public async Task<ActionResult<IEnumerable<Measurement>>> Get([FromBody] int userId, DateTime start, DateTime end)
        //{
        //    IEnumerable<Measurement> measurementRes = await _measurementService.getMeasurementsByDate(userId, start, end);
        //    return measurementRes;
        //}

            //[HttpGet]
        //public async Task<ActionResult<Measurement>> Get([FromQuery] int userId)
        //{

        //    if (_measurementService.getLastMeasurement(userId) != null)
        //    {
        //        Measurement lastMesurment = await _measurementService.getLastMeasurement(userId);
        //        MeasurementDTO lastMesurmentDTO = _mapper.Map<MeasurementDTO>(lastMesurment);
        //        return Ok(lastMesurment);
        //    }
        //    return NoContent();
        //}




        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<MeasurementDTO>>> Get([FromQuery] int userId, DateTime start, DateTime end)
        //{
        //    IEnumerable<Measurement> measurementRes = await _measurementService.getMeasurementsByDate(userId, start, end);
        //    IEnumerable<MeasurementDTO> measurementResDTO = _mapper.Map<IEnumerable<Measurement>, IEnumerable<MeasurementDTO>>(measurementRes);
        //    if (measurementRes == null)
        //    {
        //        return NoContent();
        //    }
        //    return Ok(measurementRes);

        //}
        //[HttpPost]
        //public async Task<ActionResult<Measurement>> Post([FromBody] MeasurementDTO measurement)
        //{
        //    Measurement newMeasurement = _mapper.Map<MeasurementDTO, Measurement>(measurement);
        //    newMeasurement.User = null;
        //    Measurement ms = await _measurementService.addMeasurement(newMeasurement);
        //    return ms;

        //}
        

//            [HttpPost]
//            public async Task<ActionResult<Measurement>> Post(Measurement measurement)
//            {
//                Measurement m = await _measurementService.addMeasurement(measurement);
//                return m;
//            }

    

