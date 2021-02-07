using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ContactsWebApp.Data;
using ContactsWebApp.Helper;
using ContactsWebApp.Models;

namespace ContactsWebApp.Controllers
{
    public class ContactsController : Controller
    {
        private ContactsContext db = new ContactsContext();
        private static List<Country> countries = new List<Country>();

        // GET: Contacts
        public ActionResult Index()
        {
            return View(db.Contacts.ToList());
        }

        // GET: Contacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacts contacts = db.Contacts.Find(id);
            if (contacts == null)
            {
                return HttpNotFound();
            }
            return View(contacts);
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {
            #region Load country list for drop down list
            countries = LoadHelper.Countries();
            ViewBag.country = from cL in countries
                              select new SelectListItem 
                              {
                                  Text = cL.Name,
                                  Value = cL.Name
                              };
            #endregion

            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ContactType,MainName,TradeName,DocumentNumber,Birthday,Gender,Country,State,City,ZipCode,AddressLine1,AddressLine2")] Contacts contacts)
        {
            //Validates the information provided for the new Contact
            ValidationHelper.ContactInformation(ModelState, contacts);

            if (ModelState.IsValid)
            {
                db.Contacts.Add(contacts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                #region Reload country list for drop down list
                ViewBag.country = from cL in countries
                                  select new SelectListItem
                                  {
                                      Text = cL.Name,
                                      Value = cL.Name
                                  };
                #endregion
            }

            return View(contacts);
        }

        // GET: Contacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacts contacts = db.Contacts.Find(id);
            if (contacts == null)
            {
                return HttpNotFound();
            }

            #region Load country list for drop down list
            countries = LoadHelper.Countries();
            ViewBag.country = from cL in countries
                              select new SelectListItem
                              {
                                  Text = cL.Name,
                                  Value = cL.Name
                              };
            #endregion

            return View(contacts);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ContactType,MainName,TradeName,DocumentNumber,Birthday,Gender,Country,State,City,ZipCode,AddressLine1,AddressLine2")] Contacts contacts)
        {
            //Validates the information provided for an exiting Contact
            ValidationHelper.ContactInformation(ModelState, contacts);

            if (ModelState.IsValid)
            {
                db.Entry(contacts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                #region Reload country list for drop down list
                countries = LoadHelper.Countries();
                ViewBag.country = from cL in countries
                                  select new SelectListItem
                                  {
                                      Text = cL.Name,
                                      Value = cL.Name
                                  };
                #endregion
            }

            return View(contacts);
        }

        // GET: Contacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacts contacts = db.Contacts.Find(id);
            if (contacts == null)
            {
                return HttpNotFound();
            }
            return View(contacts);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contacts contacts = db.Contacts.Find(id);
            db.Contacts.Remove(contacts);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Dispose DB
        /// </summary>
        /// <param name="disposing">Indicates to dispose or not</param>
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
