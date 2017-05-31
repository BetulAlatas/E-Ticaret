using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProgramlama.Models
{
    public class LoginControl
    {

        public bool Control()
        {

            if (Convert.ToInt32(HttpContext.Current.Session["Giris"]) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}