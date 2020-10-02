using DiscogymPUMA2020.Models.Class;
using DiscogymPUMA2020.Models.Interface;
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
            throw new NotImplementedException();
        }

        public IEnumerable<Log> GetLogsByMood(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Log> GetLogsByUser(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Log> GetLogsByWorkout(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveLog(int? id)
        {
            throw new NotImplementedException();
        }

        public void UpdateLog(Log log)
        {
            throw new NotImplementedException();
        }
    }
}
