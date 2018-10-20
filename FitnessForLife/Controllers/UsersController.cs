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
using FitnessForLife.Utils;
using System.IO;

namespace FitnessForLife.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private FitnessForLifeModel db = new FitnessForLifeModel();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user.Path == null)
            {
                user.Path = "defaultpic.jpg";
            }
            if (user == null)
            {
                return HttpNotFound();
            }
            if (User.IsInRole("FitnessManager"))
            {
                return View("DetailsAdmin", user);
            }
            return View("DetailsUser", user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,First_Name,Last_Name,Date_of_birth,Address,PhoneNumber,Path")] User user, HttpPostedFileBase postedFile)
        {
            ModelState.Clear();
            var myUniqueFileName = string.Format(@"{0}", Guid.NewGuid());
            user.Path = myUniqueFileName;
            TryValidateModel(user);

            if (ModelState.IsValid)
            {
                try
                {
                    string toEmail = User.Identity.GetUserName();
                    string subject = "Welcome to Fitness For Life";
                    string contents = "You have successfully registered with fitness for life. " +
                                        "Now you can access our facilities by booking appointment with our fitness consultant" +
                                        "<br><br>Let's begin our journey to fitness!!!";

                    EmailSender es = new EmailSender();
                    es.Send(toEmail, subject, contents);
                    ModelState.Clear();
                }
                catch
                {
                    return View();
                }

                string serverPath = Server.MapPath("~/Uploads/");
                string fileExtension = Path.GetExtension(postedFile.FileName);
                string filePath = user.Path + fileExtension;
                user.Path = filePath;
                postedFile.SaveAs(serverPath + user.Path);

                user.Id = User.Identity.GetUserId();
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,First_Name,Last_Name,Date_of_birth,Address,PhoneNumber,Path")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
