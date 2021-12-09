using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace AP5_New.Models
{
    public partial class ContainerMaster
    {
        [Display(Name = "廠別")]
        public string PlantCode { get; set; }

        [Display(Name = "下櫃日期")]
        public string UnboxDate { get; set; }

        [Display(Name = "直別")]
        public int ShiftType { get; set; }

        [Display(Name = "國別")]
        public string Country { get; set; }

        [Display(Name = "貨櫃連番")]
        public string ContainerRenban { get; set; }

        [Display(Name = "貨櫃號碼")]
        public string ContainerNo { get; set; }

        [Display(Name = "碼頭代號")]
        public int DockNo { get; set; }

        [Display(Name = "下櫃台數")]
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

        [Display(Name = "下櫃狀態")]
        public string ContainerStatus { get; set; }
    }
}
