using System;
using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.BusinessLayer
{
    public class PenaltyCalculator : IPenaltyCalculator
    {

        // This function return two things 
        // Businessdays and penaulty amount 
        public PenaltyInfo Calculate(DateTime startDate, DateTime endDate, CountryInfo countryInfo)
        {
            PenaltyInfo penaltyInfo = new PenaltyInfo();
            penaltyInfo.BusinessDays = CalculateBusinessDays(startDate, endDate, countryInfo.Weekends, countryInfo.PublicHolidays);
            penaltyInfo.TotalAmount = CalculatePenalty(penaltyInfo.BusinessDays, countryInfo.DueDateCharges, countryInfo.TaxPercentage);

            return penaltyInfo;
        }



        // This function is used to calculate the business days which takes four things as a input
        //startdate, End date , List of weekends for weekends , list of public holidays 
        // we simply start a loop from start date to end date by the increment of one day
        // at the start the number of business days are zero.
        // I will increment the business days only if it neither a weekend nor a public holidays
        // id a day is neiher a public holiday nor a weekend then that day should be a business days

        private int CalculateBusinessDays(DateTime startDate, DateTime endDate, List<string> weekends, List<DateTime> publicHolidays)
        {
            int numberOfBusinessDays = 0;

            // start a loop from start date to end date by the increment of one day

            for (DateTime day = startDate.Date; day.Date <= endDate.Date; day = day.AddDays(1))
            {
                // 

                if (!(weekends.Exists(weekend => weekend.ToLower() == day.DayOfWeek.ToString().ToLower()) || publicHolidays.Exists(holiday => holiday.Date == day)))
                {
                    numberOfBusinessDays++;
                }
            }

            return numberOfBusinessDays;
        }

        // calculte the penaulty amount
        // If the business days are less than then it retur zero value
        // If the business days are greter than  10 then it calculates the penaulty amount based on the tax applied to it 

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
