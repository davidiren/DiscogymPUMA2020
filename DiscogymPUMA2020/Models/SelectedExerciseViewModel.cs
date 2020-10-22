using DiscogymPUMA2020.Models.Class;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscogymPUMA2020.Models
{
    public class SelectedExerciseViewModel
    {
        public CategoryViewModel CategoryView { get; set; }
        public IEnumerable<Exercise> Exercises { get; set; }
        public List<string> SelectedExrcises { get; set; }


    }
}
