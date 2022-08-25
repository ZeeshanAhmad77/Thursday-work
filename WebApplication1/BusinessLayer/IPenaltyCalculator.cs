using System;
using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.BusinessLayer
{
    public interface IPenaltyCalculator
    {
        PenaltyInfo Calculate(DateTime startDate, DateTime endDate, CountryInfo countryInfo);
    }
}
