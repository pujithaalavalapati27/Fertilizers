using Microsoft.AspNetCore.Mvc;
using BigHatDataApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Data;
using BigHatDataApi.Models;
using MySql.Data.MySqlClient;
using System.Web;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection.PortableExecutable;





namespace BigHatDataApi.Controller
{

    [ApiController]
    [Route("[controller]")]

    public class Nutrients : ControllerBase
    {
    
        private SqlConnection GetConnection()
        {

            string connectionString = ("Data Source=DESKTOP-FE0J905; Initial Catalog=BigHaatData;User id=sa; Password=myServer$786#;");
            return new SqlConnection(connectionString);

        }
        [HttpGet]
        public List<Data> GetAllvegitableseeds()
        {
            List<Data> list = new List<Data>();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Nutrients", conn);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Data()
                            {
                                Product_Id = reader.GetInt32("ProductID"),
                                ProductName = reader["ProductName"].ToString(),
                                SellingPrice = reader.GetInt32("SellingPrice"),
                                OfferPrice = reader.GetInt32("OfferPrice"),
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return list;

        }
    }


}



