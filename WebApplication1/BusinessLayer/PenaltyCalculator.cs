using System;
using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.BusinessLayer
{
    public class PenaltyCalculator : IPenaltyCalculator
    {
        public PenaltyInfo Calculate(DateTime startDate, DateTime endDate, CountryInfo countryInfo)
        {
            PenaltyInfo penaltyInfo = new PenaltyInfo();
            penaltyInfo.BusinessDays = CalculateBusinessDays(startDate, endDate, countryInfo.Weekends, countryInfo.PublicHolidays);
            penaltyInfo.TotalAmount = CalculatePenalty(penaltyInfo.BusinessDays, countryInfo.DueDateCharges, countryInfo.TaxPercentage);

            return penaltyInfo;
        }

        private int CalculateBusinessDays(DateTime startDate, DateTime endDate, List<string> weekends, List<DateTime> publicHolidays)
        {
            int numberOfBusinessDays = 0;
            for (DateTime day = startDate.Date; day.Date <= endDate.Date; day = day.AddDays(1))
            {
                if (!(weekends.Exists(weekend => weekend.ToLower() == day.DayOfWeek.ToString().ToLower()) || publicHolidays.Exists(holiday => holiday.Date == day)))
                {
                    numberOfBusinessDays++;
                }
            }

            return numberOfBusinessDays;
        }

        private double CalculatePenalty(int busninessDays, double fine, double tax)
        {
            if (busninessDays <= 10)
            {
                return 0;
            }

            double totalAmount = 0;
            int lateDays = busninessDays - 10;

            for (int i = 0; i < lateDays; i++)
            {
                totalAmount = (totalAmount + fine) + ((totalAmount + fine) * (tax / 100));
            }
            return totalAmount;
        }


    }
}
