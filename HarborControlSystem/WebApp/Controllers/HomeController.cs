using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.ErrorLog;
using UI.Utility;

namespace WebApp.Controllers
{
    [ExceptionHandler]
    public class HomeController : Controller
    {
        /// <summary>
        /// Harbor control page
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// Generate random boats
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>

        public ActionResult Boats(int count)
        {
            return PartialView("_BoatHarbor", GenerateRandomBoats.Boats(count));

        }
    }
}