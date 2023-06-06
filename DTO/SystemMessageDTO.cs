using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SystemMessageDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string MessageText { get; set; } = null!;
        public DateTime Date { get; set; }
        public bool IsRead { get; set; }
    }
}
