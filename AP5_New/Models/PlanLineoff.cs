using System;
using System.Collections.Generic;

#nullable disable

namespace AP5_New.Models
{
    public partial class PlanLineoff
    {
        public string PlantCode { get; set; }
        public int? ShiftType { get; set; }
        public int? Lineoff { get; set; }
        public string StartDt { get; set; }
        public string EndDt { get; set; }
    }
}
