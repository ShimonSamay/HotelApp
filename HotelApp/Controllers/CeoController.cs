using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelApp.Models;

namespace HotelApp.Controllers
{
    public class CeoController : Controller
    {
        public List<Ceo> ceoList = new List<Ceo>();
        
        public ActionResult getName()
        {
            fillList();
            return View(ceoList[ceoList.Count-1]);
        }

        public ActionResult getCeo (int id)
        {
            fillList();
            ViewBag.ceo = ceoList.Find(ceo => ceo.Id == id);    
            return View();
        }

        private void fillList ()
        {
            ceoList.Add(new Ceo(1,"shimon samay" , 22 , "shimn@" , 2000));
            ceoList.Add(new Ceo(2, "lior yoswf", 24, "lior@", 7000));
            ceoList.Add(new Ceo(3, "eli belay", 25, "eli@", 9000));
            ceoList.Add(new Ceo(4, "avi admaso", 29, "avi@", 4000));
            ceoList.Add(new Ceo(5, "matan", 28, "matan@", 5000));
        }
    }
}