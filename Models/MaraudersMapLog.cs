using System;
using System.Collections.Generic;

namespace Hogwards.Models
{

    public partial class MaraudersMapLog
    {
        public int TrackId { get; set; }

        public string WizardName { get; set; } = null!;

        public string Location { get; set; } = null!;

        public DateTime MovementTime { get; set; }
    }
}