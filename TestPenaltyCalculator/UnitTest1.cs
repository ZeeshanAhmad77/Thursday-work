using NUnit.Framework;
using System;
using System.Collections.Generic;
using WebApplication1.BusinessLayer;
using WebApplication1.Models;

namespace TestPenaltyCalculator
{
    public class Tests
    {



        [SetUp]
        public void Setup()
        {

            
        }

        [Test]
        public void CheckDetails()
        {

            PenaltyCalculator _penalutyController = new PenaltyCalculator();
            //Country _countryController = new Country();   
            DateTime startDate = new DateTime(2022, 08, 01);
            DateTime endDate = new DateTime(2022, 08, 08);
            CountryInfo countryinfo = new CountryInfo();
            countryinfo.CountryId = 1;
            countryinfo.Name = "pakistan";
            countryinfo.Currency = "PKR";
            countryinfo.DueDateCharges = 50;
            countryinfo.TaxPercentage = 0;
            List<string> weekendList = new List<string>();
            weekendList.Add("saturday");
            weekendList.Add("sunday");
            countryinfo.Weekends = weekendList;
            List<DateTime> ListPublicHoliday = new List<DateTime>();
            ListPublicHoliday.Add(new DateTime(2022, 08, 08));
            ListPublicHoliday.Add(new DateTime(2022, 08, 09));
            ListPublicHoliday.Add(new DateTime(2022, 08, 14));
            countryinfo.PublicHolidays = ListPublicHoliday;

            PenaltyInfo penaltyInfo = _penalutyController.Calculate(startDate, endDate, countryinfo);
            double TotalAmount = penaltyInfo.TotalAmount;
            int BusinessDays = penaltyInfo.BusinessDays;

            Assert.AreEqual(0, TotalAmount);
            Assert.Less(10, BusinessDays);
        }
    }
}