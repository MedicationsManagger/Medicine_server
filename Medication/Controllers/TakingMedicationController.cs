using AutoMapper;
using DTO;
using Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Medication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TakingMedicationController : ControllerBase
    {
        private readonly ITakingMedicationService _takingMedicationService;
        private readonly IMapper _mapper;

        public TakingMedicationController(ITakingMedicationService takingMedicationService, IMapper mapper)
        {
            _takingMedicationService = takingMedicationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TakingMedication>>> Get([FromQuery] int takeMId)
        {
            IEnumerable<TakingMedication> taskingList = await _takingMedicationService.getTakingMedication(takeMId);
            if (taskingList == null)
            {
                return NoContent();
            }
            return Ok(taskingList);
        }

        [HttpPost]
        public async Task<ActionResult<TakingMedication>> Post (TakingMedicationDTO takingMedication)
        {
            TakingMedication tkMedication = _mapper.Map<TakingMedicationDTO, TakingMedication>(takingMedication);
            TakingMedication tm = await _takingMedicationService.addTakingMedication(tkMedication);
            return Ok(tm);
        }

       
    }
}
