using Entites;
using Medication;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Repository
{
    public class SystemMessagesRepository : ISystemMessageRepository
    {

        MedicationsContext _medicationsContext;
        public SystemMessagesRepository (MedicationsContext medicationsContext)
        {
            _medicationsContext = medicationsContext;
        }

        public async Task<IEnumerable< SystemMessage>> getSystemMessages(int userId)
        {

            var sm = (from m in _medicationsContext.SystemMessages
                      where m.UserId == userId
            select m);

            List<SystemMessage> systemMsg = await sm.ToListAsync();
            return systemMsg;

        }

        public async Task<SystemMessage> addSystemMessage(SystemMessage message)
        {
            await _medicationsContext.SystemMessages.AddAsync(message);
            await _medicationsContext.SaveChangesAsync();
            return message;


        }

        public async Task updateSystemMessage(SystemMessage message)
        {
            var smToUpdate = await _medicationsContext.SystemMessages.FindAsync(message.Id);
            if (smToUpdate == null)
            {
                return;
            }
            _medicationsContext.Entry(smToUpdate).CurrentValues.SetValues(message);
            await _medicationsContext.SaveChangesAsync();
            return;

        }
        


    }
}
