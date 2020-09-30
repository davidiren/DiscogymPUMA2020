using DiscogymPUMA2020.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscogymPUMA2020.Models.Interface
{
    public interface ILogRepo
    {
        IEnumerable<Log> GetLogs { get; }
        IEnumerable<Log> GetLogsByUser(int id);
        IEnumerable<Log> GetLogsByMood(int id);
        IEnumerable<Log> GetLogsByWorkout(int id);
        Log GetLog(int id);
        void AddLog(Log log);
        void RemoveLog(int? id);
        void UpdateLog(Log log);
    }
}
