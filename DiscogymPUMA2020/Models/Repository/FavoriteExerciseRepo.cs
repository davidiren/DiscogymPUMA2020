using DiscogymPUMA2020.Models.Class;
using DiscogymPUMA2020.Models.Interface;
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
        public IEnumerable<FavoriteExercise> GetFavoriteExercises => throw new NotImplementedException();

        public void AddFavorite(FavoriteExercise favoriteExercise)
        {
            throw new NotImplementedException();
        }

        public FavoriteExercise GetFavorite(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FavoriteExercise> GetFavoritesByUser(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FavoriteExercise> GetFavoritesByWorkout(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveFavorite(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
