using CoinListing.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CoinListing.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private CoinListingEntities db = new CoinListingEntities();

        public ActionResult Index(string searchString = "", int page = 1)
        {
            ViewBag.ActionName = "Index";
            ViewBag.ActivePage = page;
            var SubscribeStartDate = DateTime.Parse(ConfigurationManager.AppSettings["FullSubscribeStartDate"]);
            var SubscribeEndDate = DateTime.Parse(ConfigurationManager.AppSettings["FullSubscribeEndDate"]);

            var DateDiff = (SubscribeEndDate - SubscribeStartDate).TotalMinutes;
            var TodayDateDiff = (SubscribeEndDate - DateTime.Now).TotalMinutes;
            int SubscriberCount = db.Subscriptions.Count();
            var DateDiffPerc = (TodayDateDiff / DateDiff) * 100;

            if (DateDiff <= TodayDateDiff)
            {
                ViewBag.SubscriberCount = int.Parse(SubscriberCount.ToString());
            }
            else
            {
                var value = SubscriberCount * ((100 - DateDiffPerc) / 100);
                ViewBag.SubscriberCount = (int)value;
            }



            var CookieVisited = ReadCookie("Subscribe");

            ViewBag.CookieVisited = CookieVisited;

            CreateCookie("Subscribe", "true", 30);

            var model = new List<Listing>();
            var pageNo = page;
            ViewBag.searchString = searchString;

            int itemsToSkip = ((pageNo - 1) * 30);

            if (searchString == "" || searchString == null)
            {
                model = db.Listings
                    .Where(c => c.ListingStage.ListingStage1 == "Active ICO")
                    .OrderBy(g => g.Status.StatusLevel)
                    .Skip(itemsToSkip)
                    .Take(30).ToList();

                ViewBag.ListingPages = Math.Ceiling((double)db.Listings
                    .Where(c => c.ListingStage.ListingStage1 == "Active ICO")
                    .Count() / 30);
            }
            else
            {
                model = db.Listings
                    .Where(c => c.ListingStage.ListingStage1 == "Active ICO"
                    && c.CoinName.ToUpper().Contains(searchString))
                    .OrderBy(g => g.Status.StatusLevel)
                    .Skip(itemsToSkip)
                    .Take(30).ToList();

                ViewBag.ListingPages = Math.Ceiling((double)db.Listings
                    .Where(c => c.ListingStage.ListingStage1 == "Active ICO"
                    && c.CoinName.ToUpper().Contains(searchString))
                    .Count() / 30);
            }

            return View("Index", model);


        }

        public ActionResult Upcoming(string searchString = "", int page = 1)
        {
            ViewBag.ActionName = "Upcoming";
            ViewBag.ActivePage = page;
            var SubscribeStartDate = DateTime.Parse(ConfigurationManager.AppSettings["FullSubscribeStartDate"]);
            var SubscribeEndDate = DateTime.Parse(ConfigurationManager.AppSettings["FullSubscribeEndDate"]);

            var DateDiff = (SubscribeEndDate - SubscribeStartDate).TotalMinutes;
            var TodayDateDiff = (SubscribeEndDate - DateTime.Now).TotalMinutes;
            int SubscriberCount = db.Subscriptions.Count();
            var DateDiffPerc = (TodayDateDiff / DateDiff) * 100;

            if (DateDiff <= TodayDateDiff)
            {
                ViewBag.SubscriberCount = int.Parse(SubscriberCount.ToString());
            }
            else
            {
                var value = SubscriberCount * ((100 - DateDiffPerc) / 100);
                ViewBag.SubscriberCount = (int)value;
            }

            var CookieVisited = ReadCookie("Subscribe");

            ViewBag.CookieVisited = CookieVisited;
            CreateCookie("Subscribe", "true", 30);

            var model = new List<Listing>();
            var pageNo = page;
            ViewBag.searchString = searchString;

            int itemsToSkip = ((pageNo - 1) * 30);

            if (searchString == "" || searchString == null)
            {
                model = db.Listings
                    .Where(c => c.ListingStage.ListingStage1 == "Upcoming ICO")
                    .OrderBy(g => g.Status.StatusLevel)
                    .Skip(itemsToSkip)
                    .Take(30).ToList();

                ViewBag.ListingPages = Math.Ceiling((double)db.Listings
                    .Where(c => c.ListingStage.ListingStage1 == "Upcoming ICO")
                    .Count() / 30);
            }
            else
            {
                model = db.Listings
                    .Where(c => c.ListingStage.ListingStage1 == "Upcoming ICO"
                    && c.CoinName.ToUpper().Contains(searchString))
                    .OrderBy(g => g.Status.StatusLevel)
                    .Skip(itemsToSkip)
                    .Take(30).ToList();

                ViewBag.ListingPages = Math.Ceiling((double)db.Listings
                    .Where(c => c.ListingStage.ListingStage1 == "Upcoming ICO"
                    && c.CoinName.ToUpper().Contains(searchString))
                    .Count() / 30);
            }

            return View("Index", model);
        }

        public ActionResult Drafts(string searchString = "", int page = 1)
        {
            ViewBag.ActionName = "Drafts";
            ViewBag.ActivePage = page;
            var SubscribeStartDate = DateTime.Parse(ConfigurationManager.AppSettings["FullSubscribeStartDate"]);
            var SubscribeEndDate = DateTime.Parse(ConfigurationManager.AppSettings["FullSubscribeEndDate"]);

            var DateDiff = (SubscribeEndDate - SubscribeStartDate).TotalMinutes;
            var TodayDateDiff = (SubscribeEndDate - DateTime.Now).TotalMinutes;
            int SubscriberCount = db.Subscriptions.Count();
            var DateDiffPerc = (TodayDateDiff / DateDiff) * 100;

            if (DateDiff <= TodayDateDiff)
            {
                ViewBag.SubscriberCount = int.Parse(SubscriberCount.ToString());
            }
            else
            {
                var value = SubscriberCount * ((100 - DateDiffPerc) / 100);
                ViewBag.SubscriberCount = (int)value;
            }

            var CookieVisited = ReadCookie("Subscribe");

            ViewBag.CookieVisited = CookieVisited;
            CreateCookie("Subscribe", "true", 30);

            var model = new List<Listing>();
            var pageNo = page;
            ViewBag.searchString = searchString;

            int itemsToSkip = ((pageNo - 1) * 30);

            if (searchString == "" || searchString == null)
            {
                model = db.Listings
                    .Where(c => c.ListingStage.ListingStage1 == "Draft")
                    .OrderBy(g => g.Status.StatusLevel)
                    .Skip(itemsToSkip)
                    .Take(30).ToList();

                ViewBag.ListingPages = Math.Ceiling((double)db.Listings
                    .Where(c => c.ListingStage.ListingStage1 == "Draft")
                    .Count() / 30);
            }
            else
            {
                model = db.Listings
                    .Where(c => c.ListingStage.ListingStage1 == "Draft"
                    && c.CoinName.ToUpper().Contains(searchString))
                    .OrderBy(g => g.Status.StatusLevel)
                    .Skip(itemsToSkip)
                    .Take(30).ToList();

                ViewBag.ListingPages = Math.Ceiling((double)db.Listings
                    .Where(c => c.ListingStage.ListingStage1 == "Draft"
                    && c.CoinName.ToUpper().Contains(searchString))
                    .Count() / 30);
            }

            return View("Index", model);
        }

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

        public ActionResult Subscribe()
        {
            return PartialView();
        }

        public JsonResult SubscribeEmail(string email)
        {
            try
            {
                db.Subscriptions.Add(new Subscription() { Email = email, Subscribe = true });
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public HttpCookie CreateCookie(string name, string key, int days)
        {
            HttpCookie cook = new HttpCookie(name);
            cook.Value = key;
            cook.Expires = DateTime.Now.AddDays(days);

            Response.Cookies.Add(cook);
            return cook;
        }

        public HttpCookie ReadCookie(string name)
        {
            HttpCookie cook = Request.Cookies[name];
            return cook;
        }
    }
}