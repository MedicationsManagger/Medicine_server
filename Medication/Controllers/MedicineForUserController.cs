using AutoMapper;
using DTO;
using Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Services;

namespace Medication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineForUserController : ControllerBase
    {
        private readonly IMedicineForUserService _medicineForUserService;
        private readonly IMedicineService _medicineService;
        private readonly IMapper _mapper;
        public MedicineForUserController(IMedicineForUserService medicineForUserService, IMapper mapper)
        {
            _medicineForUserService = medicineForUserService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicineForUserDTO>>> Get([FromQuery] int userId)
        {



            IEnumerable<MedicineForUserDTO> medicineForUserList = await _medicineForUserService.getMedicineForUser(userId);
            if (medicineForUserList == null)
            {
                return NoContent();
            }
               

            IEnumerable<MedicineForUserDTO> medicineForUserListDTO = _mapper.Map<IEnumerable<MedicineForUserDTO>>(medicineForUserList);
            //foreach (IEnumerable < MedicineForUserDTO > x in medicineForUserListDTO)
            //{
            //    ffun(x);
            //}
           
            return Ok(medicineForUserListDTO);
        }
          

        //public void ffun(MedicineForUserDTO md)
        //{
        //    string s = _medicineService.getMedicineById(md.Id).Name; 
        //        ;
        //}


    [HttpPost]
    public async Task<ActionResult<MedicineForUserDTO>> Post([FromBody] MedicineForUserDTO medicineForUser)
    {

        MedicineForUser medicineForUserObj = _mapper.Map<MedicineForUserDTO, MedicineForUser>(medicineForUser);
        medicineForUserObj.Medicine = null;
        medicineForUserObj.User = null;
        MedicineForUser newMedicineForUser = await _medicineForUserService.addMedicineForUser(medicineForUserObj);
        MedicineForUserDTO newMedicineForUserDTO = _mapper.Map<MedicineForUserDTO>(newMedicineForUser);
        return Ok(newMedicineForUserDTO);
    }
}

    //    [HttpPut]
    //    public async Task<ActionResult> Put([FromBody] MedicineForUserDTO medicineForUpdate)
    //    {
    //        var medicineForUserObj = _mapper.Map<MedicineForUserDTO, MedicineForUser>(medicineForUpdate);

    //        if (medicineForUserObj != null)
    //            await _medicineForUserService.updateMedicineForUser(medicineForUserObj);
    //        return Ok();
    //    }

    //}
}
