using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UsersAndCaregiverDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CaregiverId { get; set; }
        public int? StatusOfCaregiverId { get; set; }

    
    }
}
