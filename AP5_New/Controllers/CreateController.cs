using AP5_New.Models;
using AP5_New.Services.IServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AP5_New.Controllers
{
    public class CreateController : Controller
    {

        private readonly string _uploadFolder;
        private readonly string _downloadFolder;
        private readonly string _sampleFolder;
        private readonly ICodeService _codeService;
        private readonly IPlanLineOffService _lineOffService;
        private readonly ILogger _logger;
        private readonly AP5_NewContext _context;

        public CreateController(
            IWebHostEnvironment hosting,
            ICodeService codeService,
            IPlanLineOffService lineOffService,
            ILogger<CreateController> logger,
            AP5_NewContext context)
        {
            _uploadFolder = $"{hosting.WebRootPath}\\FileUpload";
            _downloadFolder = $"{hosting.WebRootPath}\\FileDownload";
            _sampleFolder = $"{hosting.WebRootPath}\\Sample";
            _codeService = codeService;
            _lineOffService = lineOffService;
            _logger = logger;
            _context = context;
        }

        public IActionResult PlanLineOff()
        {
            ViewBag.plantcode = _codeService.GetPlanLineOffPlantCode(_context);
            ViewBag.shifttype = _codeService.GetPlanLineOffShiftType(_context);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PlanLineOff(PlanLineoff planLineoff, string search, string export, string delete)
        {
            //try
            //{
            //    if (!string.IsNullOrEmpty(search))
            //    {
            //        ViewBag.plantcode = _codeService.GetPlanLineOffPlantCode(_context);
            //        ViewBag.shifttype = _codeService.GetPlanLineOffShiftType(_context);

            //        ViewBag.SearchResult = _lineOffService.GetPlanLineOffByCondition(planLineoff, _context);
            //        return View();
            //    }

            //    if (!string.IsNullOrEmpty(export))
            //    {
            //        var savePath = $"{_downloadFolder}\\";
            //        List<ModMaster> sourceList = _moduleService.GetModuleByCondition(module, _context);
            //        string fileName = _codeService.exportExcel(savePath, "開梱計畫", sourceList, _context);
            //        Stream iStream = new FileStream(savePath + fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            //        TempData["Message"] = "匯出成功。";
            //        //回傳出檔案
            //        return File(iStream, "application/pdf", fileName);
            //    }
            //    if (!string.IsNullOrEmpty(delete))
            //    {
            //        List<ModMaster> deleteList = _moduleService.GetModuleByCondition(module, _context);
            //        _moduleService.DeletefromModMaster(deleteList, _context);
            //        TempData["Message"] = "刪除成功。";
            //        return View();
            //    }
            //    return null;
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError(ex.Message);
            //    throw;
            //}
            return null;
        }

    }
}
