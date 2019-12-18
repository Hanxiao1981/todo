using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Taihang.TodoWebApi.Basic.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "首页";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Title = "关于";

            return View();
        }
    }
}
