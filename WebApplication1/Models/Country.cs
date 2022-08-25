using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1.Models
{
    public class Country
    {
        public int country_id { get; set; }
        public string name { get; set; }

        public string currency { get; set; }
        public decimal special_tax { get; set; }
        public decimal due_date_charges { get; set; }

        public Country()
        {
        }


        // string cs = "";

        //public Country(IConfiguration config)
        //{
        //    cs = config.GetConnectionString("DBCS");

        //}
         string cs= "Data Source=CMDLHRDB01;Initial Catalog=PenaultyCalculator1_4060;Persist Security Info=True;User ID=zeeshan77;Password=123";
        public List<Country> GetCountries()
        {
            
            List<Country> countryList = new List<Country>();

            using (SqlConnection con = new SqlConnection(cs))
            {
                
                SqlCommand cmd = new SqlCommand("spGetCountries", con);
                cmd.CommandType = CommandType.StoredProcedure;
                   
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Country country = new Country();
                    country.country_id = Convert.ToInt32(rdr["country_id"]);
                    country.name = rdr["name"].ToString();
                    country.currency = rdr["currency"].ToString();
                    country.special_tax = Convert.ToDecimal(rdr["special_tax"]);
                    country.due_date_charges = Convert.ToDecimal(rdr["due_date_charges"]);
                    countryList.Add(country);
                }            
               
            }
            return countryList;
        }
        // To find the holidays of a country 
        //public List<DateTime> getPublicHolidays(int CountryId)
        //{
        //    Country country = new Country();
        //    using (SqlConnection con = new SqlConnection(cs))
        //    {
        //        SqlCommand cmd = new SqlCommand("spSelectEmployee", con);



        //    }



    //}
    //public int getBusinessDays(int countryId, string CheckedOutDate, string ReturnedDate)
    //{

    //    converting dates in string format to DateTime Format

    //    var checkedOutDate = DateTime.Parse(CheckedOutDate);
    //    var returnedDate = DateTime.Parse(ReturnedDate);

    //    Country country = new Country();
    //    List<String> ListOfWeekend = country.getWeekendDaysbyId(countryId);
    //    double noOfWeekDays = country.GetWeekDays(checkedOutDate, returnedDate, ListOfWeekend);

    //    return 5;


    //}
    //To find The WeekDays between two dates
    public  double GetWeekDays(DateTime startD, DateTime endD, List<string> listOfWeeked)
        {
            double calcWeekDays = 1 + ((endD - startD).TotalDays * (7-listOfWeeked.Count) - (startD.DayOfWeek - endD.DayOfWeek) * listOfWeeked.Count) / 7;
            foreach (string weekend in listOfWeeked)
            {

                switch (weekend)
                {
                    case "monday":
                        {
                            if (endD.DayOfWeek == DayOfWeek.Monday) calcWeekDays--;
                            if (startD.DayOfWeek == DayOfWeek.Monday) calcWeekDays--;
                        }
                        break;
                    case "tuesday":
                        {
                            if (endD.DayOfWeek == DayOfWeek.Tuesday) calcWeekDays--;
                            if (startD.DayOfWeek == DayOfWeek.Tuesday) calcWeekDays--;
                        }
                        break;
                    case "wednesday":
                        {
                            if (endD.DayOfWeek == DayOfWeek.Wednesday) calcWeekDays--;
                            if (startD.DayOfWeek == DayOfWeek.Wednesday) calcWeekDays--;
                        }
                        break;
                    case "thursday":
                        {
                            if (endD.DayOfWeek == DayOfWeek.Thursday) calcWeekDays--;
                            if (startD.DayOfWeek == DayOfWeek.Thursday) calcWeekDays--;
                        }
                        break;
                    case "friday":
                        {
                            if (endD.DayOfWeek == DayOfWeek.Friday) calcWeekDays--;
                            if (startD.DayOfWeek == DayOfWeek.Friday) calcWeekDays--;
                        }
                        break;
                    case "saturday":
                        {
                            if (endD.DayOfWeek == DayOfWeek.Saturday) calcWeekDays--;
                            if (startD.DayOfWeek == DayOfWeek.Saturday) calcWeekDays--;
                        }
                        break;
                    case "sunday":
                        {
                            if (endD.DayOfWeek == DayOfWeek.Sunday) calcWeekDays--;
                            if (startD.DayOfWeek == DayOfWeek.Sunday) calcWeekDays--;
                        }
                        break;
                }


            }
            return calcWeekDays;
        }

 

        //public List<string> getWeekendDaysbyId(int id)
        //{
        //    List<string> ListOfWeekend = new List<string>();
        //    Country country = new Country();

        //    using (SqlConnection con = new SqlConnection(cs))
        //    {
        //        con.Open();
        //        var sql = "select name_of_day from weekendDays WHERE  country_id=@country_id";
        //        using (var cmd = new SqlCommand(sql, con))
        //        {
        //            cmd.Parameters.AddWithValue("@country_id", id);
        //            cmd.ExecuteNonQuery();

        //        }
        //        con.Close();


        //    }

        //}

        public List<string> getWeekendDaysbyId(int id)
        {
            List<string> ListOfWeekend = new List<string>();
            Country country = new Country();

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetWeekedDaysById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@country_id ", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    string weekend = rdr["name_of_day"].ToString();
                    ListOfWeekend.Add(weekend);

                }


                return ListOfWeekend;
            }



        }


    }
}
