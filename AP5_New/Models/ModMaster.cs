using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace AP5_New.Models
{
    public partial class ModMaster
    {
        [Display(Name = "廠別")]
        public string PlantCode { get; set; }

        [Display(Name = "開梱日期")]
        public string UnboxDate { get; set; }

        [Display(Name = "直別")]
        public int ShiftType { get; set; }

        [Display(Name = "車種")]
        public string CarType { get; set; }

        [Display(Name = "國別")]
        public string Country { get; set; }

        [Display(Name = "MOD_NO")]
        public string ModNo { get; set; }

        [Display(Name = "開梱台編號")]
        public int UnboxArea { get; set; }

        [Display(Name = "開梱台數")]
        public int? LineoffCount { get; set; }

        [Display(Name = "備註")]
        public string Mark { get; set; }

        [Display(Name = "理論作業時間")]
        public int? LogicalTime { get; set; }

        [Display(Name = "開始時間")]
        public DateTime? StartTime { get; set; }

        [Display(Name = "結束時間")]
        public DateTime? EndTime { get; set; }

        [Display(Name = "相隔時間")]
        public int ProcessTime { get; set; }

        [Display(Name = "完成標記")]
        public string DoneFlag { get; set; }

        [Display(Name = "MOD狀態")]
        public string ModStatus { get; set; }
    }
}
