using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.Entities
{
    public class Setting
    {
        public int Id{  get; set; }
        public int DefualtBorrrowDays { get; set; }
        public int DefaultFinePerDay { get; set; } 

        private Setting() { }
        public Setting(int defualtBorrrowDays, int defaultFinePerDay)
        {
            DefualtBorrrowDays = defualtBorrrowDays;
            DefaultFinePerDay = defaultFinePerDay;
        }
        public void UpdateDefualtBorrrowDays(int defualtBorrrowDays)
        {
            DefualtBorrrowDays = defualtBorrrowDays;
        }

        public void UpdateDefaultFinePerDay(int defaultFinePerDay)
        {
            DefaultFinePerDay = defaultFinePerDay;
        }
    }
}
