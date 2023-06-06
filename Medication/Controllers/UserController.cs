using Microsoft.AspNetCore.Mvc;
using Services;
using DTO;
using AutoMapper;
using Entites;


namespace Medication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper= mapper;
        }


        [HttpGet("getAllUsers")]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            IEnumerable<User> usersList = await _userService.getAllUsers();
            if (usersList == null)
            {
                return NoContent();
            }
            return Ok(usersList);

        }


        [HttpGet]
    public async Task<ActionResult <UserDTO>> Get([FromQuery]string userName, string password)
        {

            if (_userService.getUser(userName, password) != null)
            {
                User user = await _userService.getUser(userName, password);
                UserDTO userDTO = _mapper.Map<UserDTO> (user); 
                return Ok(userDTO);
            }   
           
            return NotFound();
        }


        [HttpGet("getById")]
        public async Task<ActionResult<User>> Get([FromQuery] int userId)
        {
            User user = await _userService.getUserById(userId);
            if( user!=null)
            {
                return Ok(user); 
            }
            return NotFound();
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] UserDTO UDto)
        {

            User user = _mapper.Map<UserDTO, User>(UDto);
            user.Gender = null;
            User u = await _userService.addUser(user);
            return u;

        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task Put([FromBody] UserDTO userToUpdate)
        {

            var user = _mapper.Map<UserDTO, User>(userToUpdate);
            if (user != null)
                await _userService.updateUser(user);
            return;
        }

    }
}
