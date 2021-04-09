using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentCRUD.Controllers
{
    public class CRUDController : Controller
    {
        

        // GET: CRUD/Create
        public ActionResult Create()
        {
            return View();
        }
        
        // POST: CRUD/Create
        [HttpPost]
        public ActionResult Create(Student model)
        {
          using(var context = new StudentCRUDEntities())
            {
                context.Students.Add(model);
                context.SaveChanges();
                return RedirectToAction("Read");
            }

           // string message = "Created the record successfully";
           // ViewBag.Message = message;
           
        }

        [HttpGet]
        public ActionResult Read()
        {
            using (var context = new StudentCRUDEntities())
            {
                var data = context.Students.ToList();
                return View(data);
            }

        }

        // GET: CRUD/Edit/5
        public ActionResult Update(int Studentid)
        {
            using (var context = new StudentCRUDEntities())
            {
                var data = context.Students.Where(x => x.StudentNo == Studentid).SingleOrDefault();
                return View(data);
            }
        }

        // POST: CRUD/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(int Studentid, Student model)
        {
            using(var context=new StudentCRUDEntities())
            {
                var data = context.Students.FirstOrDefault(x => x.StudentNo == Studentid);

                if(data!=null)
                {
                    data.Name = model.Name;
                    data.Section = model.Section;
                    data.EmailId = model.EmailId;
                    data.Branch = model.Branch;
                    context.SaveChanges();
                    return RedirectToAction("Read");
                }
                else
                {
                    return View();
                }
            }
        }

        // GET: CRUD/Delete/5

        public ActionResult Delete(int Studentid)
        {
            using (var context = new StudentCRUDEntities())
            {
                var data = context.Students.Where(x => x.StudentNo == Studentid).SingleOrDefault();
                return View(data);
            }
        }

        // POST: CRUD/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int Studentid, Student model)
        {
            using (var context = new StudentCRUDEntities())
            {
                var data = context.Students.FirstOrDefault(x => x.StudentNo == Studentid);

                if (data != null)
                {
                    context.Students.Remove(data);
                    context.SaveChanges();
                    return RedirectToAction("Read");
                }
                else
                {
                    return View();
                }
            }
        }







        /*public ActionResult Delete()
        {
            return View();
        }
        */
        // POST: CRUD/Delete/5
      //  [HttpPost]
       /* public ActionResult Delete(int Studentid)
        {
            using (var context = new StudentCRUDEntities())
            {
                var data = context.Students.FirstOrDefault(x => x.StudentNo == Studentid);

                if (data != null)
                {
                    context.Students.Remove(data);
                    context.SaveChanges();
                    return RedirectToAction("Read");
                }
                else
                {
                    return View();
                }
            }
        }
       */
    }
}
