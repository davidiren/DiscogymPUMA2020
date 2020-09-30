using DiscogymPUMA2020.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscogymPUMA2020.Models.Interface
{
    public interface IFavoriteExerciseRepo
    {
        IEnumerable<FavoriteExercise> GetFavoriteExercises { get; }
        IEnumerable<FavoriteExercise> GetFavoritesByUser(int id);
        IEnumerable<FavoriteExercise> GetFavoritesByWorkout(int id);
        FavoriteExercise GetFavorite(int id);
        void AddFavorite(FavoriteExercise favoriteExercise);
        void RemoveFavorite(int? id);
    }
}
