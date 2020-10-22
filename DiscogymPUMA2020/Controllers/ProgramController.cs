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
using System.Security.Cryptography.X509Certificates;

namespace DiscogymPUMA2020.Controllers
{
    public class ProgramController : Controller
    {
        private readonly IWorkoutExerciseRepo _workoutExercise;
        private readonly IWorkoutRepo _workout;
        private readonly IExerciseRepo _exercise;
        private readonly ICategoryRepo _category;
        private readonly IUserRepo _user;
        private readonly IExerciseLevelRepo _exerciseLevel;
        private CategoryViewModel categoryViewModel;
        private List<Exercise> chosenExercise = new List<Exercise>();
        public ProgramController(IWorkoutExerciseRepo workoutExercise, IWorkoutRepo workout, IExerciseRepo exercise, ICategoryRepo category, IUserRepo user, IExerciseLevelRepo exerciseLevel)
        {
            _workoutExercise = workoutExercise;
            _workout = workout;
            _exercise = exercise;
            _category = category;
            _user = user;
            _exerciseLevel = exerciseLevel;

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
        public IActionResult Create(string serializedModel)
        {
            if (CurrentUser == 0)
            {
                 return RedirectToAction("Index", "Plan");
            }
            List<string> eList = new List<string>(); 
            if (serializedModel != null)
            {
                List<string> exercises = JsonConvert.DeserializeObject<List<string>>(serializedModel);
                foreach(string s in exercises)
                {
                    chosenExercise.Add(_exercise.GetExercise(int.Parse(s)));
                    eList.Add(s);
                }
            }
            
            ViewData["Exercises"] = chosenExercise;
            ViewData["Gym"] = new List<SelectListItem>()
            {
                new SelectListItem(){Text= "Gym", Value="true"},
                new SelectListItem(){Text= "Home", Value= "false"}
            };
            if(eList.Count > 0)
            {
                string st = JsonConvert.SerializeObject(eList);
                HttpContext.Session.SetString("ChosenExercises", st);
            }
            return View();
        }

        //POST: ProgramController/Create
        [HttpPost]
        public IActionResult Create(Workout workout)
        {
            var userId = _user.GetUser(CurrentUser).Id;
            string exList = HttpContext.Session.GetString("ChosenExercises");
            List<string> Exercises = JsonConvert.DeserializeObject<List<string>>(exList);
            if (workout != null)
            {
                workout.CreatedByUserId = userId;
                workout.WorkoutTime = 5;
                _workout.AddWorkout(workout);                
            }

            WorkoutExercise newWorkoutExercise = new WorkoutExercise();
            foreach (string s in Exercises)
            {
                newWorkoutExercise.ExerciseId = _exercise.GetExercise(int.Parse(s)).Id;
                var w = _workout.GetWorkoutsByName(userId, workout.Name).ToList();
                newWorkoutExercise.WorkoutId = w.First().Id;

                _workoutExercise.AddWorkoutExercise(newWorkoutExercise);
            }

            return RedirectToAction("TrainingView");
        }

        
        public IActionResult CreateWorkoutExercise(string selectedCat)
        {
            var exercises = _exercise.GetExercises;
            if (!String.IsNullOrEmpty(selectedCat))
            {
                categoryViewModel.SelectedCategories.Add(selectedCat);
                exercises = _exercise.GetExercisesByCategory(IntegerType.FromString(selectedCat));
            }
            /*var model = new Tuple<CategoryViewModel, IEnumerable<Exercise>>
                (categoryViewModel, exercises);*/
            var model = new SelectedExerciseViewModel();
            model.CategoryView = categoryViewModel;
            model.Exercises = exercises;
            return View(model);
        }

        public IActionResult ChosenWorkoutExercise(List<string> selectedEx)
        {
            if (selectedEx is null)
            {
                return RedirectToAction("CreateWorkoutExercise");
            }
            return RedirectToAction("Create", "Program", new { serializedModel = JsonConvert.SerializeObject(selectedEx) });
        } 

        public IActionResult TrainingView(int id)
        {
            var workout = _workout.GetWorkout(id);
            var exercise = _exercise.GetExercise(workout.WorkoutExercises.FirstOrDefault(x => x.ExerciseId > 0).ExerciseId);
            ViewBag.Level = _exerciseLevel.GetExerciseLevel(exercise.LevelId).Name;
            ViewBag.Exercises = _workoutExercise.GetWorkoutExercisesByWorkout(id);
            return View(workout);
        }

        public IActionResult TrainingPlay(int id)
        {
            var workoutName = _workout.GetWorkout(id).Name;
            ViewBag.Name = workoutName;
            ViewBag.Exercises = _workoutExercise.GetWorkoutExercisesByWorkout(id);
            return View();
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
