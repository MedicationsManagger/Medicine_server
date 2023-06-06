using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Entites;
using DTO;

namespace Medication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineService _medicineService;
        private readonly IMapper _mapper;
        public MedicineController(IMedicineService medicineService, IMapper mapper)
        {
            _medicineService = medicineService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medicine>>> Get()
        {
            IEnumerable<Medicine> res = await _medicineService.getAllMedicines();
            if (res == null)
            {
                return NoContent();
            }

            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult< Medicine>> Get([FromQuery]int medicineId)
        {
            Medicine res = await _medicineService.getMedicineById(medicineId);
            if (res == null)
            {
                return NoContent();
            }
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult<Medicine>> Post (Medicine medicineToAdd)
        {
           // Medicine medicineToAddObj = _mapper.Map<MedicineDTO, Medicine>(medicineToAdd);
            Medicine res = await _medicineService.addMedicine(medicineToAdd);
            return Ok(res);
        }

        //[HttpDelete]
        //public async Task<ActionResult> Delete (int medicineId)
        //{
        //    await _medicineService.deleteMedicine(medicineId);
        //    return Ok();

        //}




    }
}
