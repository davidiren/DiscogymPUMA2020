using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DiscogymPUMA2020.Models.Helpers
{
    public class DateHelper
    {
        public DateTime Today { get; set; }
        private DateTime StartOfWeek { get; set; }
        private string FullWeek { get; set; }
        private List<DayAndDate> FormatedWeek;

        public DateHelper()
        {
            Today = DateTime.Today.Date;
            FormatedWeek = new List<DayAndDate>();
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
            //Console.WriteLine("Today: {0}", Today);
            //Console.WriteLine("start of week: {0}", StartOfWeek);
            //Console.WriteLine("FullWeek: {0}", FullWeek);
            MakeProperWeekFormat();
            
        }

        //denna funktion tar in ett datum (ex. 22) och tar sedan nuvarande vecka hittar dagen som är 
        //i detta fall 22, och returnerar DateTime objektet för den dagen.
        //Används endast då man använder vecko-preview fältet.
        public DateTime GetSelectedDayFromDate(string date)
        {
            DateTime SelectedDay = new DateTime();

            string week = FullWeek = string.Join("," , Enumerable.Range(0, 7).Select(i => StartOfWeek.AddDays(i).ToString("d")));
            string[] week1 = week.Split(",");

            foreach (string s in week1)
            {
                if (s.Contains(date))
                {
                    SelectedDay = DateTime.Parse(s).Date;
                }
            }

            return SelectedDay;
        }

        /**
* This gives == exempelvis 07-T, i.e. dagens datum och första bokstaven för dagen
*/
        private void MakeProperWeekFormat()
        {
            string[] splitWeek = FullWeek.ToUpper().Split(","); //fixa capslock på allt och dela upp alla dagar
            int i = 0;
            
            foreach(string s in splitWeek)
            {
                splitWeek[i] = s.Substring(0, 4);
                //FormatedWeek.Add(new DayAndDate(splitWeek[i].Substring(0,2), splitWeek[i].Substring(2, 2)));
                DayAndDate temp = new DayAndDate(splitWeek[i].Split("-"));
                FormatedWeek.Add(temp);
                i++;
            }
        }

        public List<DayAndDate> GetFormatedWeek()
        {
            return FormatedWeek;
        }
        
    }

    public class DayAndDate
    {
        public DayAndDate() { }
        public DayAndDate(string datum, string letter)
        {
            this.Date = datum;
            this.WeekdayLetter = letter;
        }
        public DayAndDate(string[] splitter)
        {
            this.Date = splitter[0];
            this.WeekdayLetter = splitter[1];
        }
        public string Date { get; set; }
        public string WeekdayLetter { get; set; }
        public string LetterAndDate { get => WeekdayLetter + Environment.NewLine + Date; }

    }
}
