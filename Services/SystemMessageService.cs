using Entites;
using Medication;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SystemMessageService : ISystemMessageService
    {

        private ISystemMessageRepository _SystemMessageRepository;

        public SystemMessageService(ISystemMessageRepository SystemMessageRepository)
        {
            _SystemMessageRepository = SystemMessageRepository;
        }

        public async Task<IEnumerable<SystemMessage>> getSystemMessages(int userId)
        {
            return await _SystemMessageRepository.getSystemMessages(userId);

        }


        public async Task <SystemMessage> addSystemMessage(SystemMessage message)
        {
            await _SystemMessageRepository.addSystemMessage(message);
            return message;
        }

        public async Task updateSystemMessage(SystemMessage message)
        {
            await _SystemMessageRepository.updateSystemMessage(message);
        }
    }
}
