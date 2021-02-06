using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ContactType,MainName,TradeName,DocumentNumber,Birthday,Gender,Address")] Contacts contacts)
        {
            if (ModelState.IsValid)
            {
                #region Initialization
                bool isValidDocumentNumber = false;
                #endregion

                #region Fields that must be null depending on Contact Type
                switch (contacts.ContactType)
                {
                    case "Natural Person":
                        contacts.TradeName = null;
                        break;
                    case "Legal Person":
                        contacts.Birthday = null;
                        contacts.Gender = null;
                        break;
                    default:
                        //Error message: Not valid contact type
                        break;
                }
                #endregion

                #region Document Number (CPF/CNPJ) Validation
                isValidDocumentNumber = ValidationHelper.DocumentNumber(contacts);
                #endregion

                #region Natural Person
                //Natural person: Name, CPF, Birthday, Gender and Address (ZipCode, Country, State, City, Address line 1 and Address line 2).

                #endregion

                #region Legal Person
                //Legal person: Company name, Trade name, CNPJ and Address (ZipCode, Country, State, City, Address line 1 and Address line 2).

                #endregion

                db.Contacts.Add(contacts);
                db.SaveChanges();
                return RedirectToAction("Index");
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
            return View(contacts);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ContactType,MainName,TradeName,DocumentNumber,Birthday,Gender,Address")] Contacts contacts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contacts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
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
