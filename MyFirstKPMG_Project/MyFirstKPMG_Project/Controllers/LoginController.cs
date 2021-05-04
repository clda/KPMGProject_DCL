using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MyFirstKPMG_Project.Filters;
using MyFirstKPMG_Project.Models;

namespace MyFirstKPMG_Project.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult VerifyUser(tblUserLoginDetail UserDetail, string buttonSubmit)
        {
            if (buttonSubmit == null)
                ModelState.Clear();

            if(ModelState.IsValid && buttonSubmit!=null)
            {
                using (DARSHANEntities2 db = new DARSHANEntities2())
                {
                    var Details = db.Proc_UserLogin(UserDetail.vchUserName).FirstOrDefault();

                    if(Details != null)
                    {
                        var hash = GenerateHash(Details.vchUserPassword);

                        if (hash == UserDetail.vchUserPassword && Details.vchUserRole == "User")
                        {
                            FormsAuthentication.SetAuthCookie(UserDetail.vchUserName, false);
                            return RedirectToAction("LoginUser");
                        }
                        else
                        {
                            ViewBag.Error = "Invalid Credentials, Re-Enter password";
                        }
                    }
                    else
                    {
                        ViewBag.Error = "Invalid Credential, Please give correct Username";
                    }

                }
            }
            
            
            return View();
        }

        private  string GenerateHash(string value)
        {
            string DecodedValue = Encoding.UTF8.GetString(Convert.FromBase64String(value));
            return DecodedValue;
        }

        [AuthenticationFilter]
        public ActionResult LoginUser()
        {
            return View();
        }

        public ActionResult UserSignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("VerifyUser");
        }
    }
}