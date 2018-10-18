using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FitnessForLife.Models;
using Microsoft.AspNet.Identity;

namespace FitnessForLife.Controllers
{
    [Authorize]
    public class AppointmentsController : Controller
    {
        private FitnessForLifeModel db = new FitnessForLifeModel();

        // GET: Appointments
        public ActionResult Index()
        {
            var appointmentsAdmin = db.Appointments.Include(a => a.Branch1).Include(a => a.Consultant1).Include(a => a.User);
            var appointmentsUser = db.Appointments.Where(a => a.UserId == null).Include(a => a.Branch1).Include(a => a.Consultant1).Include(a => a.User);
            if (User.IsInRole("FitnessManager"))
                return View("IndexAdmin", appointmentsAdmin.ToList());

            return View("IndexUser", appointmentsUser.ToList());
        }

        // GET: Appointments/Details/5
        [Authorize(Roles = "FitnessManager")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // GET: Appointments/Create
        [Authorize(Roles = "FitnessManager")]
        public ActionResult Create()
        {
            ViewBag.Branch = new SelectList(db.Branches, "Id", "Description");
            ViewBag.Consultant = new SelectList(db.Consultants, "Id", "Full_Name");
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "FitnessManager")]
        public ActionResult Create([Bind(Include = "Id,UserId,Date,Time,Branch,Consultant")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                appointment.UserId = null;
                db.Appointments.Add(appointment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Branch = new SelectList(db.Branches, "Id", "Description", appointment.Branch);
            ViewBag.Consultant = new SelectList(db.Consultants, "Id", "Full_Name", appointment.Consultant);
            return View(appointment);
        }

        // GET: Appointments/Book/5
        public ActionResult Book(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            appointment.UserId = User.Identity.GetUserId();
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Book/5
        [HttpPost, ActionName("Book")]
        [ValidateAntiForgeryToken]
        public ActionResult BookConfirmed(int id)
        {
            Appointment appointment = db.Appointments.Find(id);
            appointment.UserId = User.Identity.GetUserId();
            db.Entry(appointment).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Manage");
        }

        // GET: Appointments/Manage
        public ActionResult Manage()
        {
            var uId = User.Identity.GetUserId();
            var appointments = db.Appointments.Where(a => a.UserId == uId).Include(a => a.Branch1).Include(a => a.Consultant1).Include(a => a.User);
            return View(appointments.ToList());
        }

        // GET: Appointments/Cancel/5
        public ActionResult Cancel(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            appointment.UserId = User.Identity.GetUserId();
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Cancel/5
        [HttpPost, ActionName("Cancel")]
        [ValidateAntiForgeryToken]
        public ActionResult CancelConfirmed(int id)
        {
            Appointment appointment = db.Appointments.Find(id);
            appointment.UserId = null;
            db.Entry(appointment).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Manage");
        }

        // GET: Appointments/Edit/5
        [Authorize(Roles = "FitnessManager")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            ViewBag.Branch = new SelectList(db.Branches, "Id", "Description", appointment.Branch);
            ViewBag.Consultant = new SelectList(db.Consultants, "Id", "Full_Name", appointment.Consultant);
            return View(appointment);
        }
    

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "FitnessManager")]
        public ActionResult Edit([Bind(Include = "Id,UserId,Date,Time,Branch,Consultant")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Branch = new SelectList(db.Branches, "Id", "Description", appointment.Branch);
            ViewBag.Consultant = new SelectList(db.Consultants, "Id", "Full_Name", appointment.Consultant);
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        [Authorize(Roles = "FitnessManager")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "FitnessManager")]
        public ActionResult DeleteConfirmed(int id)
        {
            Appointment appointment = db.Appointments.Find(id);
            db.Appointments.Remove(appointment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
