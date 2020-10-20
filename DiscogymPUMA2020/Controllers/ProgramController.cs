using DiscogymPUMA2020.Models;
using DiscogymPUMA2020.Models.Class;
using DiscogymPUMA2020.Models.Helpers;
using DiscogymPUMA2020.Models.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DiscogymPUMA2020.Controllers
{
    public class ProgramController : Controller
    {
        private readonly IWorkoutExerciseRepo _workoutExercise;
        private readonly IWorkoutRepo _workout;
        private readonly IExerciseRepo _exercise;
        private readonly ICategoryRepo _category;
        private CategoryViewModel categoryViewModel;

        public ProgramController(IWorkoutExerciseRepo workoutExercise, IWorkoutRepo workout, IExerciseRepo exercise, ICategoryRepo category)
        {
            _workoutExercise = workoutExercise;
            _workout = workout;
            _exercise = exercise;
            _category = category;

            //Create selectable categories
            List<SelectListItem> categorySelectList = new List<SelectListItem>();
            foreach (Category c in _category.GetCategories)
            {
                SelectListItem selectListItem = new SelectListItem()
                {
                    Text = c.Name,
                    Value = c.Id.ToString(),
                    Selected = c.Selected
                };
                categorySelectList.Add(selectListItem);
            }
            categoryViewModel = new CategoryViewModel(categorySelectList);

        }

        // GET: ProgramController
        public IActionResult Index(string gym, string selectedCat)
        {

            ViewData["GymSort"] = String.IsNullOrEmpty(gym)? "gym" : "";
            var workouts = _workout.GetWorkouts; 

            if (!String.IsNullOrEmpty(selectedCat))
            {
                var category = categoryViewModel.Categories.Where(r => r.Value == selectedCat).First();
                List<Workout> workouts1 = new List<Workout>();
                if (categoryViewModel.SelectedCategories.Contains(selectedCat))
                {
                    categoryViewModel.SelectedCategories.Remove(selectedCat);                    
                    category.Selected = false;
                }
                else
                {
                    categoryViewModel.SelectedCategories.Add(selectedCat);
                    category.Selected = true;
                }

                foreach (string s in categoryViewModel.SelectedCategories)
                {
                    var w1 = _workoutExercise.GetWorkoutExercisesByCategory(IntegerType.FromString(s)).ToList();
                    if(w1 != null)
                    {
                        
                        foreach(WorkoutExercise we in w1)
                        {
                            var m =_workout.GetWorkout(we.WorkoutId);
                            if (!workouts1.Contains(m)) { workouts1.Add(m); }
                        }
                        
                    }
                }

                var model1 = new Tuple<CategoryViewModel, IEnumerable<Workout>>
                (categoryViewModel, workouts1.AsEnumerable());

                return View(model1);               
            }
            else {
                switch (gym)
                {
                    case "gym":
                        workouts = _workout.GetWorkoutsByGym(true);
                        break;
                    default:
                        workouts = _workout.GetWorkoutsByGym(false);
                        break;

                }
            }
            
            var model = new Tuple<CategoryViewModel, IEnumerable<Workout>>
                (categoryViewModel, workouts);
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
            /* if (CurrentUser == 0)
             {
                 return RedirectToAction("Index", "Plan");
             }*/

            ViewData["Gym"] = new List<SelectListItem>()
            {
                new SelectListItem(){Text= "Gym", Value="1"},
                new SelectListItem(){Text= "Home", Value= "0"}
            };

            return View();
        }

        //POST: ProgramController/Create
        [HttpPost]
        public IActionResult Create(Workout workout)
        {
            return View(workout);
        }

        public IActionResult CreateWorkoutExercise(string selectedCat)
        {
            var exercises = _exercise.GetExercises;
            if (!String.IsNullOrEmpty(selectedCat))
            {
                categoryViewModel.SelectedCategories.Add(selectedCat);
                exercises = _exercise.GetExercisesByCategory(IntegerType.FromString(selectedCat));
            }
            var model = new Tuple<CategoryViewModel, IEnumerable<Exercise>>
                (categoryViewModel, exercises);

            return View(model);
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
