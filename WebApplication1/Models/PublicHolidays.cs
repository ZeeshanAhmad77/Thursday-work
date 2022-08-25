using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

using System.Data;
using System.Data.SqlClient;


namespace WebApplication1.Models
{
    public class PublicHolidays
    {
        public int holiday_id  { get; set; }
        public DateTime holiday_date  { get; set; }

        public string holiday_name  { get; set; }

        //Connection string

        string cs = "Data Source = DESKTOP - DG3EAQ0; Initial Catalog = penaultyCalculator_4060; Integrated Security = True; User ID=sa;Password=CureMD2022";

        public List<PublicHolidays> getHolidaysbyId(int id)
        {

            List<PublicHolidays> publicHolidaysList = new List<PublicHolidays>();

            using (SqlConnection con = new SqlConnection(cs))
            {

                SqlCommand cmd = new SqlCommand("spGetCountries", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@holiday_id", id);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    PublicHolidays publicHolidays = new PublicHolidays();
                    publicHolidays.holiday_id = Convert.ToInt32(rdr["holiday_id"]);
                    publicHolidays.holiday_date = Convert.ToDateTime(rdr["holiday_date"]);
                    publicHolidays.holiday_name = rdr["holiday_name"].ToString();
                    publicHolidaysList.Add(publicHolidays);
                }

            }
            return publicHolidaysList;
        }
    }
}
