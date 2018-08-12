using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CoinListing.Models;
using System.IO;
using System.Net.Mail;
using System.Configuration;

namespace CoinListing.Controllers
{
    public class ListingsController : Controller
    {
        private CoinListingEntities db = new CoinListingEntities();

        // GET: Listings
        public ActionResult Index()
        {

            return View(db.Listings.ToList());
        }

        [AllowAnonymous]
        // GET: Listings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Listing listing = db.Listings.Find(id);
            if (listing == null)
            {
                return HttpNotFound();
            }
            return View(listing);
        }

        // GET: Listings/Create
        public ActionResult Create()
        {
            ViewBag.Status = db.Status.ToList();
            ViewBag.Progress = db.Progresses.ToList();
            ViewBag.ListingStage = db.ListingStages.ToList();
            return View(new Listing());
        }

        // POST: Listings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Listing listing, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    if (file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Images"), fileName);

                        var newName = Guid.NewGuid().ToString() + "." + file.ContentType.Replace("image/", "");
                        var newpath = path.Replace(fileName, newName);

                        file.SaveAs(newpath);

                        listing.Image = "Images/" + newName;

                    }
                }
                catch (Exception e)
                {
                    ViewBag.Message = "Upload Failed";
                    return RedirectToAction("Create");
                }

                if (listing.VideoLink != null)
                {
                    listing.VideoLink = listing.VideoLink.Replace("/watch?v=", "/embed/");
                }

                db.Listings.Add(listing);
                db.SaveChanges();


            }
            return RedirectToAction("Index");
        }

        // GET: Listings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Listing listing = db.Listings.Find(id);
            if (listing == null)
            {
                return HttpNotFound();
            }
            ViewBag.Status = db.Status.ToList();
            ViewBag.Progress = db.Progresses.ToList();
            ViewBag.ListingStage = db.ListingStages.ToList();
            return View(listing);
        }

        // POST: Listings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Listing listing, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (file != null)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Images"), fileName);

                        var newName = Guid.NewGuid().ToString() + "." + file.ContentType.Replace("image/", "");
                        var newpath = path.Replace(fileName, newName);

                        file.SaveAs(newpath);

                        listing.Image = "Images/" + newName;

                    }
                }
                catch (Exception e)
                {
                    ViewBag.Message = "Upload Failed";
                    return RedirectToAction("Create");
                }

                if (listing.VideoLink != null)
                {
                    listing.VideoLink = listing.VideoLink.Replace("/watch?v=", "/embed/");
                }

                db.Entry(listing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(listing);
        }

        // GET: Listings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Listing listing = db.Listings.Find(id);
            if (listing == null)
            {
                return HttpNotFound();
            }
            return View(listing);
        }

        // POST: Listings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Listing listing = db.Listings.Find(id);
            db.Listings.Remove(listing);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult SendEmail()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateInput(false)]
        public ActionResult SendEmail(string email, string textEmail, string subject, bool allEmails = false)
        {

            email = email.Replace("../", "https://www.globaltokensales.com/");
            email = email.Replace("../", "https://www.globaltokensales.com/");
            email = email.Replace("../", "https://www.globaltokensales.com/");
            email = email.Replace("../", "https://www.globaltokensales.com/");
            email = email.Replace("../", "https://www.globaltokensales.com/");
            email = email.Replace("../", "https://www.globaltokensales.com/");
            email = email.Replace("../", "https://www.globaltokensales.com/");
            email = email.Replace("../", "https://www.globaltokensales.com/");
            email = email.Replace("../", "https://www.globaltokensales.com/");
            email = email.Replace("../", "https://www.globaltokensales.com/");
            email = email.Replace("../", "https://www.globaltokensales.com/");
            email = email.Replace("../", "https://www.globaltokensales.com/");
            email = email.Replace("../", "https://www.globaltokensales.com/");
            email = email.Replace("../", "https://www.globaltokensales.com/");
            email = email.Replace("../", "https://www.globaltokensales.com/");
            email = email.Replace("../", "https://www.globaltokensales.com/");
            email = email.Replace("../", "https://www.globaltokensales.com/");
            email = email.Replace("../", "https://www.globaltokensales.com/");
            email = email.Replace("../", "https://www.globaltokensales.com/");
            email = email.Replace("../", "https://www.globaltokensales.com/");
            email = email.Replace("../", "https://www.globaltokensales.com/");
            email = email.Replace("../", "https://www.globaltokensales.com/");
            email = email.Replace("../", "https://www.globaltokensales.com/");
            email = email.Replace("../", "https://www.globaltokensales.com/");
            email = email.Replace("../", "https://www.globaltokensales.com/");
            email = email.Replace("../", "https://www.globaltokensales.com/");
            email = email.Replace("../", "https://www.globaltokensales.com/");
            email = email.Replace("../", "https://www.globaltokensales.com/");
            email = email.Replace("../", "https://www.globaltokensales.com/");
            email = email.Replace("../", "https://www.globaltokensales.com/");
            email = email.Replace("../", "https://www.globaltokensales.com/");
            email = email.Replace("../", "https://www.globaltokensales.com/");
            email = email.Replace("../", "https://www.globaltokensales.com/");
            email = email.Replace("../", "https://www.globaltokensales.com/");
            email = email.Replace("../", "https://www.globaltokensales.com/");
            email = email.Replace("../", "https://www.globaltokensales.com/");
            email = email.Replace("../", "https://www.globaltokensales.com/");
            email = email.Replace("../", "https://www.globaltokensales.com/");
            email = email.Replace("../", "https://www.globaltokensales.com/");
            email = email.Replace("../", "https://www.globaltokensales.com/");
            email = email.Replace("../", "https://www.globaltokensales.com/");

            SmtpClient client;
            String SMTP_Username = "";
            String SMTP_Password = "";

            SMTP_Username = ConfigurationManager.AppSettings["SMTP_Username"];
            SMTP_Password = ConfigurationManager.AppSettings["SMTP_Password"];

            client = new SmtpClient();
            client.Host = ConfigurationManager.AppSettings["SMTP_Host"];
            client.Port = int.Parse(ConfigurationManager.AppSettings["SMTP_Port"]);
            client.EnableSsl = (ConfigurationManager.AppSettings["SMTP_SSL"].ToUpper() == "TRUE") ? true : false;
            client.Timeout = int.Parse(ConfigurationManager.AppSettings["SMTP_Timeout"]);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(SMTP_Username, SMTP_Password);


            if (allEmails)
            {
                var count = db.Subscriptions.Where(c => c.Subscribe == true).Count();

                var repeatTime = count / 500;

                for (int i = 0; i < repeatTime; i++)
                {
                    MailMessage mm = new MailMessage(SMTP_Username, "support@globaltokensales.com", subject, email);

                    foreach (var item in db.Subscriptions.Where(c => c.Subscribe == true).Skip(i * 500).Take(500))
                    {
                        mm.Bcc.Add(item.Email);
                    }

                    mm.Bcc.Add(textEmail);
                    mm.IsBodyHtml = true;

                    client.Send(mm);
                }
            }
            else
            {
                MailMessage mm = new MailMessage(SMTP_Username, "support@globaltokensales.com", subject, email);
                mm.Bcc.Add(textEmail);
                mm.Bcc.Add("hpaxton@bluemonday.co.za");
                mm.Bcc.Add("ben@tripcash.org");
                mm.IsBodyHtml = true;

                client.Send(mm);
            }

            ViewBag.Success = "Emails Sent";
            ViewBag.Email = email;
            ViewBag.Subject = subject;

            return View();
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
