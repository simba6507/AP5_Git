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
    public class TestController : Controller
    {
        private readonly string _uploadFolder;
        private readonly string _downloadFolder;
        private readonly string _sampleFolder;
        private readonly ICodeService _codeService;
        private readonly IModuleService _moduleService;
        private readonly ILogger _logger;
        private readonly AP5_NewContext _context;

        public TestController(
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

        public IActionResult Index(int pageNumber=1)
        {
            return View(PaginatedList<ModMaster>.Create(_context.ModMasters.OrderByDescending(p => p.UnboxDate).ToList(),pageNumber,5));
        }
    }
}
