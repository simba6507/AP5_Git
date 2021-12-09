using System;
using System.Collections.Generic;

#nullable disable

namespace AP5_New.Models
{
    public partial class CL_TNumberOfLineOff
    {
        public DateTime OperationDate { get; set; }
        public decimal Shift { get; set; }
        public decimal NumberOfLineOff { get; set; }
        public decimal LoAdjustment { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
