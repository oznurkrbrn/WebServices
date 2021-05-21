using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Web.Services.Protocols;


namespace WebServices
{
    /// <summary>
    /// WebService1 için özet açıklama
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Bu Web Hizmeti'nin, ASP.NET AJAX kullanılarak komut dosyasından çağrılmasına, aşağıdaki satırı açıklamadan kaldırmasına olanak vermek için.
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        public UserDetails User;
        [WebMethod]
        [SoapHeader("User",Required =true)]
      
        public Bilgiler BilgileriGetir(int ID, string UserName)
        {

            Bilgiler bilgilerimiz = new Bilgiler();
                    string cs = ConfigurationManager.ConnectionStrings["DBBaglan"].ConnectionString;
            
                using (SqlConnection Con = new SqlConnection(cs))
                    {
                        SqlCommand cmd = new SqlCommand("SP_BILGILERIGETIR", Con);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter parameter = new SqlParameter();
                        parameter.ParameterName = "@ID";
                        parameter.Value = ID;

                        cmd.Parameters.Add(parameter);
                        Con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            bilgilerimiz.ID = Convert.ToInt32(dr["ID"]);
                            bilgilerimiz.Adi = dr["Adi"].ToString();
                            bilgilerimiz.Soyadi = dr["Soyadi"].ToString();

                        }
                    }
                    return bilgilerimiz;
             
        }


        [WebMethod]
        [SoapHeader("User", Required = true)]
        public Notlar NotlarıGetir(int DersID, string UserName)
        {

            Notlar notlarımız = new Notlar();
            string cs = ConfigurationManager.ConnectionStrings["DBBaglan"].ConnectionString;

            using (SqlConnection Con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SP_NOTLARIGETIR", Con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@DersID";
                parameter.Value = DersID;

                cmd.Parameters.Add(parameter);
                Con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    notlarımız.DersID = Convert.ToInt32(dr["DersID"]);
                    notlarımız.DersAdi = dr["DersAdi"].ToString();
                    notlarımız.Puan = dr["Puan"].ToString();

                }
            }
            return notlarımız;
        }
        
    }
}
