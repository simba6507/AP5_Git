using AP5_New.Models;
using AP5_New.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AP5_New.Controllers
{
    public class OperationController : Controller
    {

        private readonly ICodeService _codeService;
        private readonly IModuleService _moduleService;
        private readonly IContainerService _containerService;
        private readonly ILogger _logger;
        private readonly AP5_NewContext _context;
        private readonly CL_COUNTERDBContext _clCounterDBContext;
        private readonly KN_COUNTERDBContext _knCounterDBContext;

        public OperationController(
            ICodeService codeService,
            IModuleService moduleService,
            IContainerService containerService,
            ILogger<OperationController> logger,
            AP5_NewContext context,
            CL_COUNTERDBContext clCounterDBContext,
            KN_COUNTERDBContext knCOUNTERDBContext)
        {
            _codeService = codeService;
            _moduleService = moduleService;
            _containerService = containerService;
            _logger = logger;
            _context = context;
            _clCounterDBContext = clCounterDBContext;
            _knCounterDBContext = knCOUNTERDBContext;
        }

        [HttpPost]
        public JsonResult GetLineOff(string plantCode)
        {
            try
            {
                string actualCount = String.Empty;
                if (plantCode == "721B")
                {
                    actualCount = _codeService.GetCLLineOffCount(_clCounterDBContext);
                }
                else if (plantCode == "721C")
                {
                    actualCount = _codeService.GetKNLineOffCount(_knCounterDBContext);
                }
                //string actualCount = "60";
                // Convert array to JSON data
                return Json(new { ActualCount = actualCount });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
            
        }

        #region 開梱作業畫面
        public IActionResult ModuleOperation()
        {
            ViewBag.plantcode = _codeService.GetModulePlantCode(_context);
            ViewBag.unboxarea = _codeService.GetModuleUnboxArea(_context);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ModuleOperation(ModMaster module, string search, string start, string end)
        {
            if (!string.IsNullOrEmpty(search))
            {
                ViewBag.plantcode = _codeService.GetModulePlantCode(_context);
                ViewBag.unboxarea = _codeService.GetModuleUnboxArea(_context);
                ViewBag.SearchResult = _moduleService.GetModuleByOpSearch(module, _context);
                return View();
            }
            if (!string.IsNullOrEmpty(start))
            {
                _moduleService.StartBtnModuleOp(module, _context);
                ViewBag.plantcode = _codeService.GetModulePlantCode(_context);
                ViewBag.unboxarea = _codeService.GetModuleUnboxArea(_context);
                ViewBag.SearchResult = _moduleService.GetModuleByOpSearch(module, _context);
                return View();
            }
            if (!string.IsNullOrEmpty(end))
            {
                _moduleService.EndBtnModuleOp(module, _context);
                ViewBag.plantcode = _codeService.GetModulePlantCode(_context);
                ViewBag.unboxarea = _codeService.GetModuleUnboxArea(_context);
                ViewBag.SearchResult = _moduleService.GetModuleByOpSearch(module, _context);
                return View();
            }
            return null;
        }

        #endregion

        #region 下櫃作業畫面
        public IActionResult ContainerOperation()
        {
            try
            {
                ViewBag.plantcode = _codeService.GetContainerPlantCode(_context);
                ViewBag.dockno = _codeService.GetContainerDockNo(_context);
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
        public IActionResult ContainerOperation(ContainerMaster container, string search, string start, string end)
        {
            try
            {
                if (!string.IsNullOrEmpty(search))
                {
                    ViewBag.plantcode = _codeService.GetContainerPlantCode(_context);
                    ViewBag.dockno = _codeService.GetContainerDockNo(_context);
                    ViewBag.SearchResult = _containerService.GetContainerByOpSearch(container, _context);
                    return View();
                }
                if (!string.IsNullOrEmpty(start))
                {
                    _containerService.StartBtnContainerOp(container, _context);
                    ViewBag.plantcode = _codeService.GetContainerPlantCode(_context);
                    ViewBag.dockno = _codeService.GetContainerDockNo(_context);
                    ViewBag.SearchResult = _containerService.GetContainerByOpSearch(container, _context);
                    return View();
                }
                if (!string.IsNullOrEmpty(end))
                {
                    _containerService.EndBtnContainerOp(container, _context);
                    ViewBag.plantcode = _codeService.GetContainerPlantCode(_context);
                    ViewBag.dockno = _codeService.GetContainerDockNo(_context);
                    ViewBag.SearchResult = _containerService.GetContainerByOpSearch(container, _context);
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

        #endregion

    }
}
