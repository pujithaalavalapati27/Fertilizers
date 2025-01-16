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
    public class HatController : ControllerBase
    {
        private SqlConnection GetConnection()
        {

            string connectionString = ("Data Source=DESKTOP-FE0J905; Initial Catalog=BigHaatData;User id=sa; Password=myServer$786#;");
            return new SqlConnection(connectionString);

        }
        [HttpGet]
        public List<Data> GetAllMaterials()
        {
            List<Data> list = new List<Data>();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.data", conn);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Data()
                            {
                                Product_Id = reader.GetInt32("Product_Id"),
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




        //flowerseeds




        /* Product_Id = reader.GetOrdinal("Product_Id"),
         ProductName = reader.GetOrdinal("ProductName").ToString(),
         SellingPrice = reader.GetOrdinal("SellingPrice"),
         OfferPrice = reader.GetOrdinal("OfferPrice"),*/


        /* ccode = reader.GetOrdinal("ccode").ToString(),
         bcode = reader.GetOrdinal("bcode") .ToString(),
         igcode = reader.GetOrdinal("igcode") ,
         igname = reader.GetString(reader.GetOrdinal("igname")),
         opqty = (reader.GetOrdinal("opqty")),
         hsnc = reader.GetOrdinal("hsnc") .ToString(),
         taxp = reader.GetOrdinal("taxp"),
         */

        /*it_code = reader.GetOrdinal("it_code"),
        it_name = reader.GetOrdinal("it_name").ToString(),
        uname= reader.GetOrdinal("uname").ToString(),
        mrp = reader.GetOrdinal("mrp").ToString(),
        sprice = reader.GetOrdinal("sprice"),
        idesc = reader.GetOrdinal("idesc").ToString(),*/






        [HttpGet("{id}")]
        public List<Data> GetByIddata(int proId)
        {

            List<Data> list = new List<Data>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {

                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.data where product_Id=" + proId + "", conn);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Data()
                            {
                                Product_Id = reader.GetInt32("Product_Id"),
                                ProductName = reader["ProductName"].ToString(),
                                SellingPrice = reader.GetInt32("SellingPrice"),
                                OfferPrice = reader.GetInt32("OfferPrice"),
                            });
                        }

                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        conn.Close();

                    }
                }
            }
            catch
            {
            }

            return list;
        }
    }
}


     /*   [HttpPost]

        public int savepatientdata(Data Data)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    // SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Master ( ccode,bcode,igcode,igname,opqty,hsnc,taxp) VALUES('" + Data.ccode + "','" + Data.bcode + "','" + Data.igcode + "','" + Data.igname + "','" + Data.opqty + "','" + Data.hsnc + "','" + Data.taxp + "')", conn);

                    //SqlCommand cmd = new SqlCommand("INSERT INTO dbo.iPacks ( it_code,it_name,uname,mrp,sprice,idesc) VALUES('" + Data.it_code+ "','" + Data.it_name + "','" + Data.uname + "','" + Data.mrp + "','" + Data.sprice + "','" + Data.idesc + "',)", conn);

                    SqlCommand cmd = new SqlCommand("INSERT INTO dbo.data ( Product_Id,ProductName,SellingPrice,OfferPrice,) VALUES('" + Data.Product_Id + "','" + Data.ProductName + "','" + Data.SellingPrice + "','" + Data.OfferPrice + "',)", conn);

                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return 1;
        }




    }

    
}








   /*     [HttpPut]

        public int updatepatientdata(Data Data)
        {
            try
            {
               using (SqlConnection con = GetConnection())
                {
                    con.Open();
                    //   SqlCommand cmd = new SqlCommand("update dbo.Master set ccode='" + Convert.ToInt32(Data.ccode) + "',bcode='" + Data.bcode + "',igcode='" + Convert.ToInt32(Data.igcode) + "',igname='" + Data.igname + "',opqty='" + Convert.ToInt32(Data.opqty) + "',hsnc='" + Data.hsnc + "',taxp='" + Convert.ToInt32(Data.taxp) + "' ;", con);
                      SqlCommand cmd = new SqlCommand("update dbo.data set Product_Id='" + Convert.ToInt32(Data.Product_Id) + "',it_name='" + Data.ProductName + "',SellingPrice='" + Convert.ToInt32(Data.SellingPrice) + "',OfferPrice='" + Convert.ToInt32(Data.OfferPrice) + "' ;", con);

                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch
            {
            }
            return 1;
        }*/

      /*  [HttpDelete]
        public int deletepatientdata(int ccode)
        {
            try
            {
                using (SqlConnection con = GetConnection())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("delete from dbo.data where Product_Id=" + Product_Id + "", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch
            {
            }
            return 1;
        }*/

    

