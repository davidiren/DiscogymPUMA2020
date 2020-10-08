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
        public IActionResult Index()
        {            
            var categories = _category.GetCategories;
            var exercises = _exercise.GetExercises;

            //var model = new Tuple< IEnumerable<Category>, IEnumerable<Exercise>> (categories, exercises);

            return View(exercises);
        }

        /*

        // GET: ProgramController/Details/5
        public ActionResult Details()
        {
            return View();
        }

        // GET: ProgramController/Create
        public IActionResult Create => View();

        // POST: ProgramController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create()
        //{
        //    return View();
        //}

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
