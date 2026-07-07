using System;
using System.Collections.Generic;

namespace Hogwards.Models
{

    public partial class AuditLog
    {
        public int Id { get; set; }

        public string LogMessage { get; set; } = null!;

        public DateTime? DateTrigerred { get; set; }
    }
}