using AutoMapper;
using DTO;
using Entites;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Medication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MedicineStockController : ControllerBase
        {
            private readonly IMedicineStockService _medicineStockService;
            private readonly IMapper _mapper;
            public MedicineStockController(IMedicineStockService medicineStockService, IMapper mapper)
            {
                _medicineStockService = medicineStockService;
                _mapper = mapper;
            }
            
            //[HttpGet,]
            //public async Task<ActionResult<IEnumerable<MedicineStockDTO>>> Get([FromQuery] int userId)
            //{

            //IEnumerable<MedicineStock> medicineStock = await _medicineStockService.GetMedicineStocks(userId);
            //IEnumerable<MedicineStockDTO> msDTO = _mapper.Map<IEnumerable<MedicineStock>, IEnumerable<MedicineStockDTO>>(medicineStock);
            //if (medicineStock == null)
            //    return NoContent();
            //return Ok(medicineStock);
            //}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicineStockDTO>>> Get([FromQuery] int userId)
        {

            IEnumerable<MedicineStock> medicineStock = await _medicineStockService.GetMedicineStocks(userId);
            IEnumerable<MedicineStockDTO> msDTO = _mapper.Map<IEnumerable<MedicineStock>, IEnumerable<MedicineStockDTO>>(medicineStock);
            if (medicineStock == null)
                return NoContent();
            return Ok(medicineStock);
        }





        [HttpPost]
        public async Task<ActionResult<MedicineStock>> Post([FromBody] MedicineStockDTO medicineStockDTO)
        {
            MedicineStock ms = _mapper.Map<MedicineStockDTO, MedicineStock>(medicineStockDTO);
            ms.Medicine = null;

            MedicineStock medicineStock = await _medicineStockService.AddMedicineStock(ms);
            return medicineStock;
        }






        [HttpPut("{id}")]
        public async Task Put([FromBody] MedicineStockDTO medicineStockDTO)
        {
            var medicineStock = _mapper.Map<MedicineStockDTO, MedicineStock>(medicineStockDTO);
            if (medicineStock != null)
                await _medicineStockService.UpdateMedicineStock(medicineStock);
            return;
        }
    }

    }

