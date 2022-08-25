using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.DataLayer
{
    public class CountryData : ICountryData
    {
        IConfiguration _configuration;
        private string connString;
        public CountryData(IConfiguration conf)
        {
            _configuration = conf;
            connString = _configuration.GetConnectionString("DBCS");
        }
        public List<CountryInfo> GetAllCountriesInfo()
        {
            List<CountryInfo> countryList = new List<CountryInfo>();
            using (SqlConnection con = new SqlConnection(connString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spGetCountry", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        CountryInfo country = new CountryInfo();
                        country.CountryId = Convert.ToInt32(rdr["country_id"]);
                        country.Name = rdr["name"].ToString();
                        countryList.Add(country);
                    }
                }
                finally
                {
                    con.Close();
                }


            }
            return countryList;
        }

        public CountryInfo GetCountryInfoById(int countryId)
        {
          
            using (SqlConnection con = new SqlConnection(connString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spGetCountrybyId", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@country_id ", countryId);

                    SqlDataReader rdr = cmd.ExecuteReader();
                    CountryInfo country = new CountryInfo();
                    while (rdr.Read())
                    {
                       
                        country.CountryId = Convert.ToInt32(rdr["country_id"]);
                        country.Name = rdr["name"].ToString();
                        country.Currency = rdr["currency"].ToString().ToUpper();
                        country.TaxPercentage = Convert.ToDouble(rdr["special_tax"]);
                        country.DueDateCharges = Convert.ToDouble(rdr["due_date_charges"]);
                        country.Weekends = GetCountryWeekends(country.CountryId);
                        country.PublicHolidays = GetCountryPublicHolidays(country.CountryId);
                       
                        
                    }
                    return country;
                }
                finally
                {
                    con.Close();
                }


            }
            
        }

        private List<string> GetCountryWeekends(int countryId)
        {
            List<string> weekends = new List<string>();
            using (SqlConnection con = new SqlConnection(connString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spGetWeekedDaysById", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@country_id ", countryId);

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        string weekend = rdr["name_of_day"].ToString();
                        weekends.Add(weekend);
                    }
                }
                finally
                {
                    con.Close();
                }


            }
            return weekends;
        }

        private List<DateTime> GetCountryPublicHolidays(int countryId)
        {
            List<DateTime> publicHolidays = new List<DateTime>();
            using (SqlConnection con = new SqlConnection(connString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spGetHolidaysbyId", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@country_id ", countryId);

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        DateTime holidayDate = Convert.ToDateTime(rdr["holiday_date"]);
                        publicHolidays.Add(holidayDate);
                    }
                }
                finally
                {
                    con.Close();
                }


            }
            return publicHolidays;
        }
    }
}
