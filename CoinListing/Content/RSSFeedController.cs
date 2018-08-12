using CoinListing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace CoinListing.Content
{
    public class RSSFeedController : Controller
    {
        public ActionResult Index()
        {
            var RSSURL = "https://news.google.com/news/rss/headlines/section/q/ICO%20Crowdsale/ICO%20Crowdsale?ned=us&hl=en&gl=US";
            WebClient wclient = new WebClient();
            string RSSData = wclient.DownloadString(RSSURL);

            XDocument xml = XDocument.Parse(RSSData);
            var RSSFeedData = (from x in xml.Descendants("item")
                               select new RSSFeed
                               {
                                   Title = ((string)x.Element("title")),
                                   Link = ((string)x.Element("link")),
                                   Description = ((string)x.Element("description")),
                                   PubDate = ((string)x.Element("pubDate"))

                               });
            ViewBag.RSSFeed = RSSFeedData.ToList().Where( c=> c.Description.Contains("img"));
            ViewBag.URL = RSSURL;
            return View();
        }
    }
}