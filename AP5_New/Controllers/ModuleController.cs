using AP5_New.Models;
using AP5_New.Services.IServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AP5_New.Controllers
{
    public class ModuleController : Controller
    {
        private readonly string _uploadFolder;
        private readonly string _downloadFolder;
        private readonly string _sampleFolder;
        private readonly ICodeService _codeService;
        private readonly IModuleService _moduleService;
        private readonly ILogger _logger;
        private readonly AP5_NewContext _context;

        public ModuleController(
            IWebHostEnvironment hosting,
            ICodeService codeService,
            IModuleService moduleService,
            ILogger<ModuleController> logger,
            AP5_NewContext context)
        {
            _uploadFolder = $"{hosting.WebRootPath}\\FileUpload";
            _downloadFolder = $"{hosting.WebRootPath}\\FileDownload";
            _sampleFolder = $"{hosting.WebRootPath}\\Sample";
            _codeService = codeService;
            _moduleService = moduleService;
            _logger = logger;
            _context = context;
        }

        #region 開梱計畫做成

        [HttpGet]
        public IActionResult NewModule()
        {
            ModMaster modMaster = new ModMaster();
            return PartialView("_addModulePartialView",modMaster);
        }

        [HttpPost]
        public IActionResult NewModule(ModMaster modMaster)
        {
            modMaster.ProcessTime = 0;
            modMaster.DoneFlag = "0";
            modMaster.ModStatus = "未開梱";
            var checkMod = (from t in _context.ModMasters
                            where t.Country == modMaster.Country
                             && t.CarType == modMaster.CarType
                             && t.ModNo == modMaster.ModNo
                             select t).FirstOrDefault();
            if(checkMod != null)
            {
                TempData["Message"] = "已存在相同Module。";
                return PartialView("_addModulePartialView", modMaster);
            }
            _context.ModMasters.Add(modMaster);
            _context.SaveChanges();
            TempData["Message"] = "新增成功。";
            return PartialView("_addModulePartialView", modMaster);
        }

        [HttpGet]
        public IActionResult EditModule(string modNo,string country,string carType)
        {
            var mod = _context.ModMasters.Where(a => a.ModNo == modNo && a.Country == country && a.CarType == carType).FirstOrDefault();
            return PartialView("_editModulePartialView", mod);
        }

        [HttpPost]
        public IActionResult EditModule(ModMaster modMaster)
        {
            _context.ModMasters.Update(modMaster);
            _context.SaveChanges();
            TempData["Message"] = "更新成功。";
            return PartialView("_editModulePartialView", modMaster);
        }

        public IActionResult Plan()
        {
            try
            {
                ViewBag.plantcode = _codeService.GetModulePlantCode(_context);
                ViewBag.country = _codeService.GetModuleCountry(_context);
                ViewBag.unboxarea = _codeService.GetModuleUnboxArea(_context);
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Plan(ModMaster module,string btnValue)
        {
            try
            {
                if (btnValue=="Search")
                {
                    ViewBag.plantcode = _codeService.GetModulePlantCode(_context);
                    ViewBag.country = _codeService.GetModuleCountry(_context);
                    ViewBag.unboxarea = _codeService.GetModuleUnboxArea(_context);
                    List<ModMaster> sourceList = _moduleService.GetModuleByCondition(module, _context);
                    ViewBag.SearchResult = sourceList;
                    
                    return View();
                }

                if (btnValue=="Export")
                {
                    var savePath = $"{_downloadFolder}\\";
                    List<ModMaster> sourceList = _moduleService.GetModuleByCondition(module, _context);
                    string fileName = _codeService.exportExcel(savePath, "開梱計畫", sourceList, _context);
                    Stream iStream = new FileStream(savePath + fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                    TempData["Message"] = "匯出成功。";
                    //回傳出檔案
                    return File(iStream, "application/pdf", fileName);
                }
                if (btnValue=="Delete")
                {
                    List<ModMaster> deleteList = _moduleService.GetModuleByCondition(module, _context);
                    _moduleService.DeletefromModMaster(deleteList, _context);
                    TempData["Message"] = "刪除成功。";
                    return View();
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }  
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ImportfromFile(List<IFormFile> files, string submitType)
        {
            if (submitType =="Import")
            {
                try
                {
                    var size = files.Sum(f => f.Length);
                    foreach (var formFile in files)
                    {
                        string fileExtName = Path.GetExtension(formFile.FileName).ToLower();
                        if (
                            !fileExtName.Equals(".xls", StringComparison.OrdinalIgnoreCase)
                          && !fileExtName.Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
                        {
                            TempData["Message"] = "請上傳Excel格式檔案!";
                            return RedirectToAction("Plan");
                        }
                        string fileSubstring = formFile.FileName.Substring(0, 4);
                        if (fileSubstring != "開梱計畫")
                        {
                            TempData["Message"] = "檔案名稱不正確!";
                            return RedirectToAction("Plan");
                        }
                        if (formFile.Length > 0)
                        {
                            // 要存放的位置
                            var savePath = $"{_uploadFolder}\\{DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + formFile.FileName}";
                            if (!Directory.Exists(_uploadFolder))
                            {
                                Directory.CreateDirectory(_uploadFolder);
                            }
                            using (var stream = new FileStream(savePath, FileMode.Create))
                            {
                                await formFile.CopyToAsync(stream);
                                TempData["Message"] = "上傳成功";
                            }
                            TempData["Message"] = _codeService.importExcel(savePath, fileSubstring, _context);
                        }
                    }
                    return RedirectToAction("Plan");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    throw;
                }
            }

            if (submitType == "SampleDownload")
            {
                try
                {
                    var UploadSample = $"{_sampleFolder}\\開梱計畫.xlsx";

                    //取得檔案名稱
                    string filename = Path.GetFileName(UploadSample);
                    //讀成串流
                    Stream iStream = new FileStream(UploadSample, FileMode.Open, FileAccess.Read, FileShare.Read);
                    //回傳出檔案
                    return File(iStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", filename);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    throw;
                }
                
            }

            return null;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteSingleData(string key)
        {
            try
            {
                ModMaster mod = new ModMaster();
                string[] temp = key.Split(",");
                mod.ModNo = temp[0];
                mod.Country = temp[1];
                mod.CarType = temp[2];
                _moduleService.DeleteSingleModuleByKey(mod, _context);
                TempData["Message"] = "刪除成功。";
                return RedirectToAction("Plan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
            
        }

        #endregion

    }
}
