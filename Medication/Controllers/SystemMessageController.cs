using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DTO;
using AutoMapper;
using Services;
using System.Xml.Linq;
using Entites;

namespace Medication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemMessageController : ControllerBase
    {
        private readonly ISystemMessageService _SystemMessageService;
        private readonly IMapper _mapper;
        public SystemMessageController(ISystemMessageService systemMessageService, IMapper mapper)
        {
            _SystemMessageService = systemMessageService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SystemMessageDTO>>> Get([FromQuery] int userId)
        {
            IEnumerable<SystemMessage> systemMessages = await _SystemMessageService.getSystemMessages(userId);

            IEnumerable<SystemMessageDTO> msDTO = _mapper.Map<IEnumerable<SystemMessage>, IEnumerable<SystemMessageDTO>>(systemMessages);

            if (systemMessages == null)
            {
                return NoContent();
            }

            return Ok(systemMessages);
        }


        [HttpPost]
        public async Task<ActionResult<SystemMessage>> Post([FromBody] SystemMessageDTO systemMessage)
        {
            SystemMessage newSystemMessage = _mapper.Map<SystemMessageDTO, SystemMessage>(systemMessage);
            newSystemMessage.User = null;
            SystemMessage ms=await _SystemMessageService.addSystemMessage(newSystemMessage);
            return ms;

        }
       

        [HttpPut("{id}")]
        public async Task Put([FromBody] SystemMessageDTO systemMessage)
        {
            var sm = _mapper.Map<SystemMessageDTO, SystemMessage>(systemMessage);
            if(sm!=null)
                await _SystemMessageService.updateSystemMessage(sm);
            return;
        }
        




    }
}
