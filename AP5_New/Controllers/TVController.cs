using AP5_New.Models;
using AP5_New.Services.IServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AP5_New.Controllers
{
    public class TVController : Controller
    {
        private readonly ICodeService _codeService;
        private readonly IContainerService _containerService;
        private readonly IModuleService _moduleService;
        private readonly ILogger _logger;
        private readonly AP5_NewContext _context;

        public TVController(
            ICodeService codeService,
            IContainerService containerService,
            IModuleService moduleService,
            ILogger<TVController> logger,
            AP5_NewContext context)
        {
            _codeService = codeService;
            _containerService = containerService;
            _moduleService = moduleService;
            _logger = logger;
            _context = context;
        }

        public IActionResult CLModule()
        {
            try
            {
                ModMaster grid1 = new ModMaster();
                grid1.UnboxArea = 1;
                grid1.PlantCode = "721B";
                ModMaster grid2 = new ModMaster();
                grid2.UnboxArea = 2;
                grid2.PlantCode = "721B";
                ViewBag.SearchResult1 = _moduleService.GetTVModuleData(grid1, _context);
                ViewBag.SearchResult2 = _moduleService.GetTVModuleData(grid2, _context);
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
            
        }

        public IActionResult KNModule()
        {
            try
            {
                ModMaster grid1 = new ModMaster();
                grid1.UnboxArea = 1;
                grid1.PlantCode = "721C";
                ModMaster grid2 = new ModMaster();
                grid2.UnboxArea = 2;
                grid2.PlantCode = "721C";
                ViewBag.SearchResult1 = _moduleService.GetTVModuleData(grid1, _context);
                ViewBag.SearchResult2 = _moduleService.GetTVModuleData(grid2, _context);
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
            
        }

        public IActionResult CLContainer()
        {
            try
            {
                ContainerMaster grid1 = new ContainerMaster();
                grid1.DockNo = 1;
                grid1.PlantCode = "721B";
                ContainerMaster grid2 = new ContainerMaster();
                grid2.DockNo = 2;
                grid2.PlantCode = "721B";
                ViewBag.SearchResult1 = _containerService.GetTVContainerData(grid1, _context);
                ViewBag.SearchResult2 = _containerService.GetTVContainerData(grid2, _context);
                return View(); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
            
        }

        public IActionResult KNContainer()
        {
            try
            {
                ContainerMaster grid1 = new ContainerMaster();
                grid1.DockNo = 1;
                grid1.PlantCode = "721C";
                ContainerMaster grid2 = new ContainerMaster();
                grid2.DockNo = 2;
                grid2.PlantCode = "721C";
                ViewBag.SearchResult1 = _containerService.GetTVContainerData(grid1, _context);
                ViewBag.SearchResult2 = _containerService.GetTVContainerData(grid2, _context);
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
            
        }
    }
}
