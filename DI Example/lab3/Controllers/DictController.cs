using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;
using System;

using DI.MyClasses;

namespace DI.Controllers
{
    public class DictController : Controller
    {
        // GET: Dict
        static string p1 = "http://localhost:41203";
        static string p2 = "https://localhost:44375";
        static string p3 = "http://172.16.193.234:41203/lab6";

        public static string path { get; private set; } = p1;

        IPhoneDictionary context = null;

        public DictController(IPhoneDictionary context) 
        {
            this.context = context;
        }

        public ActionResult Index()
        {
            ViewBag.data = context.GetAllSorted();
            //context.GetAllSorted();
            return View();
        }

        public ActionResult Add() 
        {
            return View();
        }

        public ActionResult AddSave()
        {
            if (Request.Params["press"].Equals("Отмена"))
            {
                return Redirect(path);
            }

            context.Insert(Request.Params["surname"], Request.Params["number"]);
            return Redirect(path);
        }

        public ActionResult Update()
        {
            lineById();
            return View();
        }

        public ActionResult UpdateSave()
        {
            if (Request.Params["press"].Equals("Отмена"))
            {
                return Redirect(path);
            }

            context.Update(Convert.ToInt32(Request.Params["id"]), Request.Params["surname"], Request.Params["number"]);
            return Redirect(path);
        }

        public ActionResult Delete()
        {
            lineById();
            return View();
        }
        private void lineById() 
        {
            var id = Convert.ToInt32(Request.Params["id"]);
            var line = context.GetLineById(id);
            ViewBag.line = line;
        }

        public ActionResult DeleteSave()
        {
            if (Request.Params["press"].Equals("Нет"))
            {
                return Redirect(path);
            }

            context.Delete(Convert.ToInt32(Request.Params["id"]));
            return Redirect(path);
        }

        public ActionResult Default()
        {
            ViewBag.request = this.HttpContext.Request;
            //ViewBag.wrongUri = Request.Params["aspxerrorpath"];
            return View();
        }
    }
}