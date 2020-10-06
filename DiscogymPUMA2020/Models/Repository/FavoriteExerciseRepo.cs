using DiscogymPUMA2020.Models.Class;
using DiscogymPUMA2020.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscogymPUMA2020.Models.Repository
{
    public class FavoriteExerciseRepo : IFavoriteExerciseRepo
    {
        protected readonly Context context;
        public FavoriteExerciseRepo(Context _context)
        {
            context = _context;
        }
        public IEnumerable<FavoriteExercise> GetFavoriteExercises => context.FavoriteExercise;

        public void AddFavorite(FavoriteExercise favoriteExercise)
        {
            context.FavoriteExercise.Add(favoriteExercise);
            context.SaveChangesAsync();
        }

        public IEnumerable<FavoriteExercise> GetFavoritesByUser(int id)
        {
            return context.FavoriteExercise.Where(r => r.UserId == id).Include(r => r.User);
        }

        public IEnumerable<FavoriteExercise> GetFavoritesByWorkout(int id)
        {
            return context.FavoriteExercise.Where(r => r.WorkoutId == id).Include(r => r.Workout);
        }

        public void RemoveFavorite(int? id)
        {
            FavoriteExercise favoriteExercise = context.FavoriteExercise.Find(id);
            context.FavoriteExercise.Remove(favoriteExercise);
            context.SaveChangesAsync();
        }
    }
}
