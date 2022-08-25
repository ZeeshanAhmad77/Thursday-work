using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

namespace GetStudentData.Models
{
    public class Country
    {
        public int  country_id  { get; set; }
        public string name  { get; set; }

        public string currency  { get; set; }
        public decimal special_tax  { get; set; }
        public decimal due_date_charges{ get; set; }

        public Country GetCountryWithId(int id)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            Country country = new Country();
            using (SqlConnection con = new SqlConnection(cs))
            {

                SqlCommand cmd = new SqlCommand("spGetCountrybyId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@country_id", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    country.country_id = Convert.ToInt32(rdr["country_id"]);
                    country.name = rdr["name"].ToString();
                    country.currency = rdr["currency"].ToString();
                    country.special_tax = Convert.ToDecimal(rdr["special_tax"]);
                    country.due_date_charges = Convert.ToDecimal(rdr["due_date_charges"]);

                }

            }
            return country;
        }



        public int getBusinessDays(int countryId,string CheckedOutDate,string ReturnedDate) {

            //converting dates in string format to DateTime Format

            var checkedOutDate = DateTime.Parse(CheckedOutDate);
            var returnedDate = DateTime.Parse(ReturnedDate);







        }





    }
}