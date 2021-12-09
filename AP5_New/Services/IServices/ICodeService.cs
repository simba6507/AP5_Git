
using AP5_New.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AP5_New.Services.IServices
{
    public interface ICodeService
    {
        public List<SelectListItem> GetModulePlantCode(AP5_NewContext _context);

        public List<SelectListItem> GetModuleCountry(AP5_NewContext _context);

        public List<SelectListItem> GetModuleUnboxArea(AP5_NewContext _context);

        public List<SelectListItem> GetContainerPlantCode(AP5_NewContext _context);

        public List<SelectListItem> GetContainerCountry(AP5_NewContext _context);

        public List<SelectListItem> GetContainerDockNo(AP5_NewContext _context);

        public List<SelectListItem> GetPlanLineOffPlantCode(AP5_NewContext _context);

        public List<SelectListItem> GetPlanLineOffShiftType(AP5_NewContext _context);

        public string importExcel(string fileName,string fileSubstring, AP5_NewContext _context);

        public string exportExcel<T>(string savePath, string fileSubstring, List<T> sourceList, AP5_NewContext _context);

        public string GetCLLineOffCount(CL_COUNTERDBContext _context);

        public string GetKNLineOffCount(KN_COUNTERDBContext _context);

    }
}
