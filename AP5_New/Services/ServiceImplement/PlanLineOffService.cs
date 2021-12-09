using AP5_New.Models;
using AP5_New.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AP5_New.Services.ServiceImplement
{
    public class PlanLineOffService : IPlanLineOffService
    {
        public List<PlanLineoff> GetPlanLineOffByCondition(PlanLineoff planLineOff,AP5_NewContext _context)
        {
            var resultList = (from t in _context.PlanLineoffs
                              where ((Int32.Parse(t.StartDt) <= Int32.Parse(planLineOff.StartDt) && Int32.Parse(t.EndDt) >= Int32.Parse(planLineOff.StartDt)) || planLineOff.StartDt == null)
                                && (t.PlantCode == planLineOff.PlantCode || planLineOff.PlantCode == null)
                                && (t.ShiftType == planLineOff.ShiftType || planLineOff.ShiftType == null)
                              orderby t.StartDt descending, t.PlantCode ascending, t.ShiftType ascending
                              select t);
            return resultList.ToList();
        }
    }
}
