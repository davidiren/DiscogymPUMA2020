using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace DiscogymPUMA2020.Models.Helpers
{
    public class DateHelper
    {
        private string Today { get; set; }
        private DateTime StartOfWeek { get; set; }
        private string FullWeek { get; set; }
        private string[] FormatedWeek;

        public DateHelper()
        {
            Today = DateTime.Today.ToString("D");
            GetWeekDay();
        }

        public void Refresh()
        {
            GetWeekDay();
        }

        /**
         * Denna funktion fixar så att man får tag hela nuvarande vecka
         */
        private void GetWeekDay()
        {
            CultureInfo myCI = new CultureInfo("sv-SE");
            Calendar myCal = myCI.Calendar;
            CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;

            StartOfWeek = DateTime.Today.AddDays((int)myFirstDOW - (int)DateTime.Today.DayOfWeek);

            //Notera att denna inte hanterar åäö, men ska endast använda första bokstaven i orden så det lär vara okej
            FullWeek = string.Join("," /*+ Environment.NewLine*/, Enumerable.Range(0, 7).Select(i => StartOfWeek.AddDays(i).ToString("dd-dddd"))); 

            //testing
            Console.WriteLine("Today: {0}", Today);
            Console.WriteLine("start of week: {0}", StartOfWeek);
            Console.WriteLine("FullWeek: {0}", FullWeek);
            MakeProperWeekFormat();
            
        }

        private void MakeProperWeekFormat()
        {
            string[] splitWeek = FullWeek.ToUpper().Split(",");
            int i = 0;
            
            foreach(string s in splitWeek)
            {
                splitWeek[i] = s.Substring(0, 4);
                Console.WriteLine(splitWeek[i]);
                i++;
            }
            FormatedWeek = splitWeek;
        }

        public string[] GetFormatedWeek()
        {
            return FormatedWeek;
        }
        
    }
}
