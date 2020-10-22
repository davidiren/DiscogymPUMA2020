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
        private readonly IWorkoutExerciseRepo _workoutExerciseRepo;
        private readonly IUserRepo _userRepo;
        private readonly ILogger<PlanController> _logger;
        private DateHelper _dateHelper;

        public PlanController(ILogger<PlanController> logger, ICategoryRepo categoryRepo,
            IPlanRepo planRepo, IWorkoutRepo workoutRepo, IUserRepo userRepo, IWorkoutExerciseRepo workoutExerciseRepo)
        {
            _categoryRepo = categoryRepo;
            _logger = logger;
            _planRepo = planRepo;
            _workoutRepo = workoutRepo;
            _workoutExerciseRepo = workoutExerciseRepo;
            _userRepo = userRepo;
            _dateHelper = new DateHelper();
            
        }

        [HttpGet]
        public IActionResult Index()
        {

            //inloggad som användare 1 vid start'
            //CurrentUser = 1;
            
            var today = _dateHelper.Today;
            PlannerHelper plannerHelper = new PlannerHelper()
            {
                SpecificDay = today,
                Week = _dateHelper.GetFormatedWeek(),
                Plans = _planRepo.GetPlansByDate(today)
            };

            ViewData["User"] = CurrentUser;

            return View(plannerHelper);
        }

        [HttpPost]
        public IActionResult Index(LoginUser user)
        {
            User dbuser = _userRepo.GetUserByName(user.UserName);
            var today = _dateHelper.Today;
            ViewData["User"] = CurrentUser;
            PlannerHelper plannerHelper = new PlannerHelper()
            {
                SpecificDay = today,
                Week = _dateHelper.GetFormatedWeek(),
                Plans = _planRepo.GetPlansByDate(today)
            };

            if(dbuser == null)
            {
                ViewBag.Error = "Wrong Username or Password";
                return View(plannerHelper);
            }

            if (dbuser.Pswd.Equals(user.Password))
            {
                CurrentUser = dbuser.Id;
                ViewBag.Error = "";
            }
            else
            {
                ViewBag.Error = "Wrong Username or Password";
                return View(plannerHelper);
            }
            ViewData["User"] = CurrentUser;

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

            ViewData["User"] = CurrentUser;

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

            _planRepo.AddPlan(temp);

            System.Threading.Thread.Sleep(500);

            return RedirectToAction("PlannerSpecificDate", new { day = DateTime.Parse(SelectedDay).Day.ToString() });

            //return View("PlannerSpecificDate", DateTime.Parse(SelectedDay).Day);
        }

        public IActionResult CheckWorkout(int workoutId)
        {
            var exercises = _workoutExerciseRepo.GetWorkoutExercisesByWorkout(workoutId);
            return View(exercises);
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

        //session variabel så man alltid vet vilken dag som inspekteras
        public string SelectedDay
        {
            get
            {
                return (string)JsonConvert.DeserializeObject(HttpContext.Session.GetString("SelectedDay"));
            }
            set
            {
                HttpContext.Session.SetString("SelectedDay", JsonConvert.SerializeObject(value));
            }
        }

        public int CurrentUser
        {
            get
            {
                if (HttpContext.Session.GetString("CurrentUser") == null)
                    return 0;

                return Convert.ToInt32(JsonConvert.DeserializeObject(HttpContext.Session.GetString("CurrentUser")));
            }
            set
            {
                HttpContext.Session.SetString("CurrentUser", JsonConvert.SerializeObject(value));
            }
        }
    }
}
