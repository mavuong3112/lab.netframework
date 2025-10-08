using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace emxinhsayhi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}

namespace emxinhsayhi.Controllers
{
    public class StoreController : Controller
    {
        public ActionResult Index() => View();
        public ActionResult Browse(string genre)
        {
            ViewBag.Genre = genre;
            return View();
        }
        public ActionResult Details(int id)
        {
            ViewBag.AlbumId = id;
            return View();
        }
    }
}