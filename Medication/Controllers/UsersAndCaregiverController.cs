using AutoMapper;
using DTO;
using Entites;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Medication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersAndCaregiverController : ControllerBase
    {
        private readonly IUsersAndCaregiverService _usersAndCaregiverService;
        private readonly IMapper _mapper;

        public UsersAndCaregiverController(IUsersAndCaregiverService UsersAndCaregiver, IMapper mapper)
        {
            _usersAndCaregiverService = UsersAndCaregiver;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsersAndCaregiverDTO>>> Get([FromQuery] int userId)
        {
            IEnumerable<UserAndCaregiver> userAndCaregiver = await _usersAndCaregiverService.getCaregiver(userId);

            IEnumerable<UsersAndCaregiverDTO> uacDTO = _mapper.Map<IEnumerable<UserAndCaregiver>, IEnumerable<UsersAndCaregiverDTO>>(userAndCaregiver);

            if (userAndCaregiver == null)
            {
                return NoContent();
            }

            return Ok(uacDTO);
        }


        [HttpPost]
        public async Task<ActionResult<UserAndCaregiver>> Post([FromBody] UsersAndCaregiverDTO uacDTO)
        {
            UserAndCaregiver Newuac = _mapper.Map<UsersAndCaregiverDTO, UserAndCaregiver>(uacDTO);
            Newuac.User = null;
            UserAndCaregiver uac = await _usersAndCaregiverService.addCaregiver(Newuac);
            return uac;

        }


        [HttpPut("{id}")]
        public async Task Put([FromBody] UsersAndCaregiverDTO uacDTO)
        {
            var uac = _mapper.Map<UsersAndCaregiverDTO, UserAndCaregiver>(uacDTO);
            if (uac != null)
                await _usersAndCaregiverService.update(uac);
            return;
        }





    }
}
