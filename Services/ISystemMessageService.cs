using Entites;
using Medication;

namespace Services
{
    public interface ISystemMessageService
    {

        public Task<IEnumerable<SystemMessage>> getSystemMessages(int userId);
        public Task <SystemMessage> addSystemMessage(SystemMessage message);
        public Task updateSystemMessage(SystemMessage message);

    }
}