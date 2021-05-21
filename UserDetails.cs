using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace WebServices
{


    public class UserDetails : System.Web.Services.Protocols.SoapHeader
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public bool IsValid()
        {
            return this.UserName == "test" && this.Password == "test12345";
        }
    }
}