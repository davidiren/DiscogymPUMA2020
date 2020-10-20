using DiscogymPUMA2020.Models.Class;
using DiscogymPUMA2020.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscogymPUMA2020.Models.Repository
{
    public class LogRepo : ILogRepo
    {
        protected readonly Context context;
        public LogRepo(Context _context)
        {
            context = _context;
        }
        public IEnumerable<Log> GetLogs => context.Log;

        public void AddLog(Log log)
        {
            context.Log.Add(log);
            context.SaveChangesAsync();
        }

        public Log GetLog(int id)
        {
            return context.Log.Find(id);
        }

        public IEnumerable<Log> GetLogsByMood(int id)
        {
            return context.Log.Where(r => r.MoodId == id)
                .Include(r => r.Mood);
        }

        public IEnumerable<Log> GetLogsByUser(int id)
        {
            return context.Log.Where(r => r.UserId == id)
                .Include(r => r.User)
                .Include(r => r.Workout)
                .Include(r => r.Mood);
        }

        public IEnumerable<Log> GetLogsByWorkout(int id)
        {
            return context.Log.Where(r => r.WorkoutId== id)
                .Include(r => r.Workout);
        }

        public void RemoveLog(int? id)
        {
            Log log = context.Log.Find(id);
            context.Log.Remove(log);
            context.SaveChangesAsync();
        }

        public void UpdateLog(Log log)
        {
            context.Log.Update(log);
            context.SaveChangesAsync();
        }
    }
}
