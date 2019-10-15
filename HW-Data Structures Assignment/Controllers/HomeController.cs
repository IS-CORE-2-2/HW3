using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW_Data_Structures_Assignment.Controllers
{
    public class HomeController : Controller
    {
        //displays index
        public ActionResult Index()
        {
            return View();
        }

        //routes to byu.edu
        public ActionResult Exit()
        {
            return Redirect("https://www.byu.edu");
        }
    }
}