using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscogymPUMA2020.Models.Interface;
using DiscogymPUMA2020.Models.Class;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.VisualBasic.CompilerServices;

namespace DiscogymPUMA2020.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ICategoryRepo _categoryRepo;
        private readonly IFavoriteExerciseRepo _favoriteExerciseRepo;
        private readonly IWorkoutRepo _workoutRepo;
        private readonly IUserRepo _userRepo;
        private readonly ILogRepo _logRepo;
        private readonly IPlanRepo _planRepo;
        private readonly ILogger<ProfileController> _logger;
        public ProfileController(ILogger<ProfileController> logger, ICategoryRepo categoryRepo,
            IWorkoutRepo workoutRepo, IFavoriteExerciseRepo favoriteExerciseRepo, IUserRepo userRepo,
            ILogRepo logRepo, IPlanRepo planRepo)
        {
            _categoryRepo = categoryRepo;
            _logger = logger;
            _workoutRepo = workoutRepo;
            _userRepo = userRepo;
            _logRepo = logRepo;
            _favoriteExerciseRepo = favoriteExerciseRepo;
            _planRepo = planRepo;

        }

        // GET: ProfilController
        public ActionResult Index()
        {
            if (CurrentUser == 0)
            {
                return RedirectToAction("Index", "Plan");
            }

            var plans = _planRepo.GetPlansByUser(CurrentUser);
            int WeeklyGoal = 0;
            int WeeklyClear = 0;
            foreach(Plan plan in plans)
            {
                if ((plan.Date.CompareTo(DateTime.Now.StartOfWeek(DayOfWeek.Monday)) >= 0)
                    && (plan.Date.CompareTo(DateTime.Now.EndOfWeek(DayOfWeek.Sunday)) <= 0))
                {
                    WeeklyGoal++;
                }
                if ((plan.Date.CompareTo(DateTime.Now.StartOfWeek(DayOfWeek.Monday)) >= 0)
                    && (plan.Date.CompareTo(DateTime.Now) < 0))
                {
                    WeeklyClear++;
                }
            }
            ViewBag.WeeklyGoal = WeeklyGoal;
            ViewBag.WeeklyClear = WeeklyClear; //"weekly clear" är just nu inte 100% då "logs" inte är fullt implementerade
            return View();
        }

        public ActionResult SavedWorkouts(bool mine)
        {
            if (mine)
            {
                ViewData["Title"] = "My Created Workouts";
                var workouts = _workoutRepo.GetWorkoutsByUser(CurrentUser);
                return View(workouts);
            }
            else
            {
                ViewData["Title"] = "Saved Workouts";
                var savedWorkouts = _favoriteExerciseRepo.GetSavedWorkoutsByUser(CurrentUser);
                List<Workout> workouts = new List<Workout>();
                foreach(FavoriteExercise fe in savedWorkouts)
                {
                    workouts.Add(fe.Workout);
                }
                return View(workouts);
            }
        }

        public IActionResult Settings()
        {
            var user = _userRepo.GetUser(CurrentUser);
            return View(user);
        }

        public IActionResult Logout()
        {
            CurrentUser = 0; //använder 0 som utloggat läge
            return RedirectToAction("Index", "Plan");
        }

        public IActionResult History()
        {
            var temp = _logRepo.GetLogsByUser(CurrentUser);
            return View(temp);
        }

        // GET: ProfilController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProfilController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfilController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProfilController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProfilController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProfilController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProfilController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //session variabel så man alltid vet inloggade användare, ska vara >> UserId <<
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
public static class DateTimeExtensions
{
    public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
    {
        int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
        return dt.AddDays(-1 * diff).Date;
    }
    public static DateTime EndOfWeek(this DateTime dt, DayOfWeek startOfWeek)
    {
        int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
        return dt.AddDays(1 * diff).Date;
    }
}