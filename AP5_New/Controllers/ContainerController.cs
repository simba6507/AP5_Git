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
    public class ContainerController : Controller
    {
        private readonly string _uploadFolder;
        private readonly string _downloadFolder;
        private readonly string _sampleFolder;
        private readonly ICodeService _codeService;
        private readonly IContainerService _containerService;
        private readonly AP5_NewContext _context;
        private readonly ILogger _logger;

        public ContainerController(
            IWebHostEnvironment hosting,
            ICodeService codeService,
            IContainerService containerService,
            ILogger<ContainerController> logger,
            AP5_NewContext context)
        {
            _uploadFolder = $"{hosting.WebRootPath}\\FileUpload";
            _downloadFolder = $"{hosting.WebRootPath}\\FileDownload";
            _sampleFolder = $"{hosting.WebRootPath}\\Sample";
            _codeService = codeService;
            _containerService = containerService;
            _logger = logger;
            _context = context;
        }

        #region 下櫃計畫做成


        public IActionResult NewContainer()
        {
            ContainerMaster containerMaster = new ContainerMaster();
            return PartialView("_addContainerPartialView", containerMaster);
        }

        [HttpPost]
        public IActionResult NewContainer(ContainerMaster containerMaster)
        {
            containerMaster.ProcessTime = 0;
            containerMaster.DoneFlag = "0";
            containerMaster.ContainerStatus = "未下櫃";
            var checkContainer = (from t in _context.ContainerMasters
                                  where t.ContainerNo == containerMaster.ContainerNo
                                  && t.ContainerRenban == containerMaster.ContainerRenban
                                  && t.Country == containerMaster.Country
                                  select t).FirstOrDefault();
            if(checkContainer != null)
            {

            }
            _context.ContainerMasters.Add(containerMaster);
            _context.SaveChanges();
            TempData["Message"] = "新增成功。";
            return PartialView("_addContainerPartialView", containerMaster);
        }

        [HttpGet]
        public IActionResult EditContainer(string containerNo, string country, string containerRenban)
        {
            var mod = _context.ContainerMasters.Where(a => a.ContainerNo == containerNo && a.Country == country && a.ContainerRenban == containerRenban).FirstOrDefault();
            return PartialView("_editContainerPartialView", mod);
        }

        [HttpPost]
        public IActionResult EditContainer(ContainerMaster containerMaster)
        {
            _context.ContainerMasters.Update(containerMaster);
            _context.SaveChanges();
            TempData["Message"] = "更新成功。";
            return PartialView("_editContainerPartialView", containerMaster);
        }


        public IActionResult Plan()
        {
            try
            {
                _logger.LogInformation("Test");
                ViewBag.plantcode = _codeService.GetContainerPlantCode(_context);
                ViewBag.country = _codeService.GetContainerCountry(_context);
                ViewBag.dockno = _codeService.GetContainerDockNo(_context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Plan(ContainerMaster container, string search, string export, string delete)
        {
            try
            {
                if (!string.IsNullOrEmpty(search))
                {
                    ViewBag.plantcode = _codeService.GetContainerPlantCode(_context);
                    ViewBag.country = _codeService.GetContainerCountry(_context);
                    ViewBag.dockno = _codeService.GetContainerDockNo(_context);

                    ViewBag.SearchResult = _containerService.GetContainerByCondition(container, _context);
                    return View();
                }

                if (!string.IsNullOrEmpty(export))
                {
                    var savePath = $"{_downloadFolder}\\";
                    List<ContainerMaster> sourceList = _containerService.GetContainerByCondition(container, _context);
                    string fileName = _codeService.exportExcel(savePath, "下櫃計畫", sourceList, _context);
                    Stream iStream = new FileStream(savePath + fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                    TempData["Message"] = "匯出成功。";
                    //回傳出檔案
                    return File(iStream, "application/pdf", fileName);
                }
                if (!string.IsNullOrEmpty(delete))
                {
                    List<ContainerMaster> deleteList = _containerService.GetContainerByCondition(container, _context);
                    _containerService.DeletefromContainerMaster(deleteList, _context);
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
            if (submitType == "Import")
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
                        if (fileSubstring != "下櫃計畫")
                        {
                            TempData["Message"] = "檔案名稱不正確!";
                            return RedirectToAction("Plan");
                        }
                        if (formFile.Length > 0)
                        {
                            // 要存放的位置
                            var savePath = $"{_uploadFolder}\\{DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + formFile.FileName}";
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
                var UploadSample = $"{_sampleFolder}\\下櫃計畫.xlsx";

                //取得檔案名稱
                string filename = Path.GetFileName(UploadSample);
                //讀成串流
                Stream iStream = new FileStream(UploadSample, FileMode.Open, FileAccess.Read, FileShare.Read);
                //回傳出檔案
                return File(iStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", filename);
            }
            return null;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteSingleData(string key)
        {
            try
            {
                ContainerMaster container = new ContainerMaster();
                string[] temp = key.Split(",");
                container.ContainerNo = temp[0];
                container.Country = temp[1];
                container.ContainerRenban = temp[2];
                _containerService.DeleteSingleContainerByKey(container, _context);
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
