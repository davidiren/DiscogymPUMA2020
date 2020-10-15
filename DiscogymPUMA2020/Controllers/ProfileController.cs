using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscogymPUMA2020.Models.Interface;
using DiscogymPUMA2020.Models.Class;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DiscogymPUMA2020.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ICategoryRepo _categoryRepo;
        private readonly IFavoriteExerciseRepo _favoriteExerciseRepo;
        private readonly IWorkoutRepo _workoutRepo;
        private readonly ILogger<ProfileController> _logger;
        public ProfileController(ILogger<ProfileController> logger, ICategoryRepo categoryRepo, IWorkoutRepo workoutRepo, IFavoriteExerciseRepo favoriteExerciseRepo)
        {
            _categoryRepo = categoryRepo;
            _logger = logger;
            _workoutRepo = workoutRepo;
            _favoriteExerciseRepo = favoriteExerciseRepo;

        }

        // GET: ProfilController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SavedWorkouts(bool mine)
        {
            if (mine)
            {
                ViewData["Title"] = "My Created Workouts";

            }
            else
            {
                ViewData["Title"] = "Saved Workouts";

            }
            return View();
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
    }
}
