using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class CountryInfo
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public double DueDateCharges { get; set; }
        public double TaxPercentage { get; set; }
        public List<string> Weekends { get; set; }
        public List<DateTime> PublicHolidays { get; set; }
    }
}
