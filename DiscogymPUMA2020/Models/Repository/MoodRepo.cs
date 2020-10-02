using DiscogymPUMA2020.Models.Class;
using DiscogymPUMA2020.Models.Interface;
using Microsoft.AspNetCore.Razor.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscogymPUMA2020.Models.Repository
{
    public class MoodRepo : IMoodRepo
    {
        protected readonly Context context;
        public MoodRepo(Context _context)
        {
            context = _context;
        }
        public IEnumerable<Mood> GetMoods => context.Mood;

        public Mood GetMood(int id)
        {
            Mood mood = context.Mood.Find(id);
            return mood;
        }
    }
}
