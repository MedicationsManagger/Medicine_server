using System;
using System.Collections.Generic;

namespace Entites
{
    public partial class SystemMessage
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string MessageText { get; set; } = null!;
        public DateTime Date { get; set; }
        public bool IsRead { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
