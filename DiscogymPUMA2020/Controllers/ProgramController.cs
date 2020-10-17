using DiscogymPUMA2020.Models.Class;
using DiscogymPUMA2020.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Dynamic;

namespace DiscogymPUMA2020.Controllers
{
    public class ProgramController : Controller
    {
        private readonly IWorkoutExerciseRepo _workoutExercise;
        private readonly IWorkoutRepo _workout;
        private readonly IExerciseRepo _exercise;
        private readonly ICategoryRepo _category;

        public ProgramController(IWorkoutExerciseRepo workoutExercise, IWorkoutRepo workout, IExerciseRepo exercise, ICategoryRepo category)
        {
            _workoutExercise = workoutExercise;
            _workout = workout;
            _exercise = exercise;
            _category = category;
        }

        // GET: ProgramController
        public IActionResult Index(string gym)
        {

            ViewData["GymSort"] = String.IsNullOrEmpty(gym)? "gym" : "";
            var workouts = _workout.GetWorkouts;
            switch (gym)
            {
                case "gym":
                    workouts = _workout.GetWorkoutsByGym(true);
                    ViewData["WorkAt"] = "Gym";
                    break;
                default:
                    workouts = _workout.GetWorkoutsByGym(false);
                    ViewData["WorkAt"] = "Home";
                    break;

            }

            var model = new Tuple<IEnumerable<Category>, IEnumerable<Workout>>
                (_category.GetCategories, workouts);
            return View(model);
        }

        /*
        // GET: ProgramController/Details/5
        public ActionResult Details()
        {
            return View();
        } */

        //GET: ProgramController/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //POST: ProgramController/Create
        [HttpPost]
        public IActionResult Create(Workout workout)
        {
            return View(workout);
        }
        /*
        // GET: ProgramController/Edit/5
        public ActionResult Edit()
        {
            return View();
        }

        // POST: ProgramController/Edit/5
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

        // GET: ProgramController/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // POST: ProgramController/Delete/5
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
        }*/
    }
}
