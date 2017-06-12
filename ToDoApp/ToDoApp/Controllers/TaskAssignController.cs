using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToDoApp.Controllers
{
    public class TaskAssignController : Controller
    {
        private ToDoListSampleDbEntities db = new ToDoListSampleDbEntities();

        //
        // GET: /TaskAssign/

        public ActionResult Index()
        {
            var taskdetails = db.TaskDetails.Include(t => t.Assign).Include(t => t.Department).Include(t => t.Priority).Include(t => t.Status).Include(t => t.TaskType);
            return View(taskdetails.ToList());
        }

        //
        // GET: /TaskAssign/Details/5

        public ActionResult Details(int id = 0)
        {
            TaskDetail taskdetail = db.TaskDetails.Find(id);
            if (taskdetail == null)
            {
                return HttpNotFound();
            }
            return View(taskdetail);
        }

        //
        // GET: /TaskAssign/Create

        public ActionResult Create()
        {
            ViewBag.AssignId = new SelectList(db.Assigns, "Id", "AssignName");
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DepartmetName");
            ViewBag.PriorityId = new SelectList(db.Priorities, "Id", "PriorityName");
            ViewBag.StatusId = new SelectList(db.Status, "Id", "StatusName");
            ViewBag.TaskTypeId = new SelectList(db.TaskTypes, "Id", "TaskName");
            return View();
        }

        //
        // POST: /TaskAssign/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskDetail taskdetail)
        {
            if (ModelState.IsValid)
            {
                db.TaskDetails.Add(taskdetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AssignId = new SelectList(db.Assigns, "Id", "AssignName", taskdetail.AssignId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DepartmetName", taskdetail.DepartmentId);
            ViewBag.PriorityId = new SelectList(db.Priorities, "Id", "PriorityName", taskdetail.PriorityId);
            ViewBag.StatusId = new SelectList(db.Status, "Id", "StatusName", taskdetail.StatusId);
            ViewBag.TaskTypeId = new SelectList(db.TaskTypes, "Id", "TaskName", taskdetail.TaskTypeId);
            return View(taskdetail);
        }

        //
        // GET: /TaskAssign/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TaskDetail taskdetail = db.TaskDetails.Find(id);
            if (taskdetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.AssignId = new SelectList(db.Assigns, "Id", "AssignName", taskdetail.AssignId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DepartmetName", taskdetail.DepartmentId);
            ViewBag.PriorityId = new SelectList(db.Priorities, "Id", "PriorityName", taskdetail.PriorityId);
            ViewBag.StatusId = new SelectList(db.Status, "Id", "StatusName", taskdetail.StatusId);
            ViewBag.TaskTypeId = new SelectList(db.TaskTypes, "Id", "TaskName", taskdetail.TaskTypeId);
            return View(taskdetail);
        }

        //
        // POST: /TaskAssign/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TaskDetail taskdetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taskdetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AssignId = new SelectList(db.Assigns, "Id", "AssignName", taskdetail.AssignId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DepartmetName", taskdetail.DepartmentId);
            ViewBag.PriorityId = new SelectList(db.Priorities, "Id", "PriorityName", taskdetail.PriorityId);
            ViewBag.StatusId = new SelectList(db.Status, "Id", "StatusName", taskdetail.StatusId);
            ViewBag.TaskTypeId = new SelectList(db.TaskTypes, "Id", "TaskName", taskdetail.TaskTypeId);
            return View(taskdetail);
        }

        //
        // GET: /TaskAssign/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TaskDetail taskdetail = db.TaskDetails.Find(id);
            if (taskdetail == null)
            {
                return HttpNotFound();
            }
            return View(taskdetail);
        }

        //
        // POST: /TaskAssign/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaskDetail taskdetail = db.TaskDetails.Find(id);
            db.TaskDetails.Remove(taskdetail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}