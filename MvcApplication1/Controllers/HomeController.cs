using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        OfficialLanguages ol;
        Languages l;
        //
        // GET: /Home/
        public ActionResult Index()
        {

            return View();
        }

        //
        // GET: /Home/country
        
        public ActionResult country(String code)
        {
            l = new Languages(code);
            ViewBag.Language = l;

            return View(l);
        }
        //
        // GET: /Home/Willkommen
        public ActionResult countries()
        {
            //ViewBag.Test = id;
            ol = new OfficialLanguages();
            ViewBag.MyList = ol;
            return View(ol);
        }
    }
}
