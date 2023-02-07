using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DeltaWare.Models;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace DeltaWare.Controllers
{
    public class DeltaController : ApiController
    {
        [HttpPost]
        public object getINPUT_DELTA_DATA(InputfetchData input)
        {
            OutputFetchData objdata = new OutputFetchData();
            OutputFetchData fetch_data = null;
            try
            {
                DataSet ds = new DataSet();
                DataTable DELTA_TABLE = new DataTable();
                SqlConnection sqlCon = null;
                SqlCommand sqlcmd = null;
                using (sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["DELTA"].ConnectionString))
                {
                    using(sqlcmd = new SqlCommand())
                    {
                        sqlcmd.Connection = sqlCon;
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.CommandText = "PROC_Delta_ware";

                        sqlcmd.Parameters.AddWithValue("@Product_id", SqlDbType.NVarChar).Value = input.Product_Id;
                        sqlcmd.Parameters.Add("Output", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        using(SqlDataAdapter da = new SqlDataAdapter(sqlcmd))
                        {
                            da.Fill(DELTA_TABLE);
                        }

                       // sqlcmd.Close();
                       if (DELTA_TABLE.Rows.Count > 0)
                        {
                            fetch_data = new OutputFetchData();
                            objdata.Product_Name = ds.Tables[0].Rows[0]["Name"].ToString().Trim();
                            objdata.Product_descp = ds.Tables[0].Rows[0]["Description"].ToString().Trim();
                            objdata.Message = "Success";
                            return objdata;

                        }
                        else
                        {
                            objdata.Message = "Data not Found";
                            return objdata;
                        }

                    }
                }
                
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return objdata;

        }
    }
}
