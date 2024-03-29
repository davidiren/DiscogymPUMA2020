﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DiscogymPUMA2020.Models.Class
{
    public class Exercise
    {
        public Exercise()
        {
            WorkoutExercises = new HashSet<WorkoutExercise>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        [ForeignKey("ExerciseLevel")]
        public int LevelId { get; set; }
        [NotMapped]
        public bool IsSelected { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public string Video { get; set; }

        public virtual Category Category { get; set; }
        public virtual ExerciseLevel ExerciseLevel { get; set; }

        public virtual IEnumerable<WorkoutExercise> WorkoutExercises { get; set; }

    }
}
