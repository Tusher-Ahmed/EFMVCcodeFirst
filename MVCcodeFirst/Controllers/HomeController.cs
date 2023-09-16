using MVCcodeFirst.Data;
using MVCcodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCcodeFirst.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDBContext _db=new ApplicationDBContext();
        // GET: Home
        public ActionResult Index()
        {
            var data=_db.Students.ToList();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student st)
        {
            if(!ModelState.IsValid)
            {
                return View(st);
            }
            _db.Students.Add(st);
            int a = _db.SaveChanges();
            if(a > 0)
            {
                TempData["Message"] = "<script>alert('Data inserted!!')</script>";
                //ModelState.Clear();
                return RedirectToAction("Index");

            }
            else
            {
                ViewBag.Message = "<script>alert('Data is not inserted!!')</script>";
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            var data=_db.Students.FirstOrDefault(x => x.Id == id);
            if(data == null)
            {
                return RedirectToAction("Index");
            }
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(int id,Student st)
        {
            if(!ModelState.IsValid)
            {
                return View(st);
            }
            var data=_db.Students.FirstOrDefault(u=>u.Id == id);
            if(data != null)
            {
                data.Name=st.Name;
                data.Age=st.Age;
                data.Gender=st.Gender;
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

   
        public ActionResult Delete(int id)
        {
           
           var data=_db.Students.FirstOrDefault(u=>u.Id == id);
            if(data != null)
            {
                return View(data);
            }
            return RedirectToAction("Index");
           
        }

        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteItem(int id)
        {
            var data=_db.Students.FirstOrDefault(u=>u.Id == id);
            _db.Students.Remove(data);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var data=_db.Students.FirstOrDefault(u=>u.Id==id);  
            if(data != null)
            {
                return View(data);
            }
            return RedirectToAction("Index");
        }
    }
}