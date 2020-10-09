using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DiscogymPUMA2020.Models;
using DiscogymPUMA2020.Models.Interface;
using DiscogymPUMA2020.Models.Helpers;

namespace DiscogymPUMA2020.Controllers
{
    public class PlanController : Controller
    {
        private readonly ICategoryRepo _categoryRepo;
        private readonly IPlanRepo _planRepo;
        private readonly IWorkoutRepo _workoutRepo;
        private readonly ILogger<PlanController> _logger;
        private DateHelper _dateHelper;

        public PlanController(ILogger<PlanController> logger, ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
            _logger = logger;
            _dateHelper = new DateHelper();
        }

        public IActionResult Index()
        {
            //var category = _categoryRepo.GetCategories;
            var week = _dateHelper.GetFormatedWeek();
            ViewBag.Today = _dateHelper.Today;
            return View(week);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
