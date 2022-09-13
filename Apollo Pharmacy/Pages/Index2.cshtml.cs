using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Apollo_Pharmacy.Pages;
using System.Data.SqlClient;
namespace Apollo_Pharmacy.Pages
{
    public class Index2Model : PageModel
    {
        public List<HospitalInfo> hospitalList = new List<HospitalInfo>();
        public void OnGet()
        {

            String connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=pharma;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String sql = "SELECT * FROM Hospital";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            HospitalInfo hospitalInfo = new HospitalInfo();
                            hospitalInfo.hid = reader.GetString(0);
                            hospitalInfo.hname = reader.GetString(1);
                            hospitalInfo.hcity = reader.GetString(2);

                            hospitalList.Add(hospitalInfo);

                        }
                    }
                }
            }


        }
        public void OnPost()
        {

        }
    }
    public class HospitalInfo
    {
        public string hid;
        public string hname;
        public string hcity;
    }
}


