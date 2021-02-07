using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContactsWebApp.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Home Information
        /// </summary>
        /// <returns>Home View</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// About Information
        /// </summary>
        /// <returns>About View</returns>
        public ActionResult About()
        {
            ViewBag.Message = $@"This is the place where you should organize your contact list, in this web application you can register, list, view and delete contacts.";

            return View();
        }
    }
}