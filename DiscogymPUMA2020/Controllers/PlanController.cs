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
using DiscogymPUMA2020.Models.Class;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace DiscogymPUMA2020.Controllers
{
    public class PlanController : Controller
    {
        private readonly ICategoryRepo _categoryRepo;
        private readonly IPlanRepo _planRepo;
        private readonly IWorkoutRepo _workoutRepo;
        private readonly ILogger<PlanController> _logger;
        private DateHelper _dateHelper;

        public PlanController(ILogger<PlanController> logger, ICategoryRepo categoryRepo, IPlanRepo planRepo, IWorkoutRepo workoutRepo)
        {
            _categoryRepo = categoryRepo;
            _logger = logger;
            _planRepo = planRepo;
            _workoutRepo = workoutRepo;
            _dateHelper = new DateHelper();
        }

        [HttpGet]
        public IActionResult Index()
        {
            //var category = _categoryRepo.GetCategories;
            //ViewBag.Today = _dateHelper.Today;
            var today = _dateHelper.Today;
            PlannerHelper plannerHelper = new PlannerHelper()
            {
                SpecificDay = today,
                Week = _dateHelper.GetFormatedWeek(),
                Plans = _planRepo.GetPlansByDate(today)
            };

            return View(plannerHelper);
        }

        //@day - is only a date of a specific day this week
        [HttpGet]
        public IActionResult PlannerSpecificDate(string day)
        {
            //ViewBag.Today = _dateHelper.GetSelectedDayFromDate(day);
            var today = _dateHelper.GetSelectedDayFromDate(day);
            PlannerHelper plannerHelper = new PlannerHelper()
            {
                SpecificDay = today,
                Week = _dateHelper.GetFormatedWeek(),
                Plans = _planRepo.GetPlansByDate(today)
            };
            return View("Index", plannerHelper);
        }

        [HttpGet]
        public IActionResult MakePlanFromWorkout(DateTime day, string gym)
        {
            SelectedDay = day.ToString("yyyy-MM-dd");

            ViewData["GymSort"] = gym == "gym" ? "" : "gym";
            var workouts = _workoutRepo.GetWorkouts;
            switch (gym)
            {
                case "gym":
                    workouts = _workoutRepo.GetWorkoutsByGym(true);
                    ViewData["WorkAt"] = "Gym";
                    break;
                default:
                    workouts = _workoutRepo.GetWorkoutsByGym(false);
                    ViewData["WorkAt"] = "Home";
                    break;

            }

            var model = new Tuple<IEnumerable<Category>, IEnumerable<Workout>>
                (_categoryRepo.GetCategories, workouts);
            return View(model);
        }

        public IActionResult AddPlanToDB(int workoutId)
        {
            Plan temp = new Plan()
            {
                Date = DateTime.Parse(SelectedDay),
                UserId = 1, //borde vara CurrentUserId
                WorkoutId = workoutId,
            };

            //_planRepo.AddPlan(temp);
            

            return RedirectToAction("PlannerSpecificDate", new { day = DateTime.Parse(SelectedDay).Day.ToString() });

            //return View("PlannerSpecificDate", DateTime.Parse(SelectedDay).Day);
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

        public string SelectedDay
        {
            get
            {
                return (string)JsonConvert.DeserializeObject(HttpContext.Session.GetString("SelectedDay"));
                //object value = HttpContext.Session.GetString("SelectedDay");
                //return value == null ? "" : (string)value;
            }
            set
            {
                HttpContext.Session.SetString("SelectedDay", JsonConvert.SerializeObject(value));
            }
        }
    }
}
