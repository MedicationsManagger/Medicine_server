using System;
using System.Collections.Generic;

namespace Entites
{
    public partial class UserAndCaregiver
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CaregiverId { get; set; }
        public int? StatusOfCaregiverId { get; set; }

        public virtual User Caregiver { get; set; } = null!;
        public virtual CaregiverStatusCode? StatusOfCaregiver { get; set; }
        public virtual User User { get; set; } = null!;
    }
}
