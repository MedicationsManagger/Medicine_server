using Entites;
using Medication;

namespace Repository
{
    public interface ISystemMessageRepository
    {

        public Task<IEnumerable<SystemMessage>> getSystemMessages(int userId);
        public Task<SystemMessage> addSystemMessage(SystemMessage message);
        public Task updateSystemMessage(SystemMessage message);

    }
}


