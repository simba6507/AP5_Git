using AP5_New.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AP5_New.Services.IServices
{
    public interface IPlanLineOffService
    {
        public List<PlanLineoff> GetPlanLineOffByCondition(PlanLineoff planLineOff,AP5_NewContext _context);
    }
}
