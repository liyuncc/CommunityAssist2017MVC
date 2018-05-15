using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssist2017MVC.Models;

namespace CommunityAssist2017MVC.Controllers
{
    public class DonationController : Controller
    {
        // GET: Donation
        public ActionResult Index()
        {
            if (Session["PersonKey"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
                
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "PersonKey, DonationDate, DonationAmount, DonationConfirmationCode")] Donation d)
        {
            
            
            d.PersonKey = (int)Session["PersonKey"];
            d.DonationDate = DateTime.Now;
         
            d.DonationConfirmationCode = Guid.NewGuid();

            CommunityAssist2017Entities db = new CommunityAssist2017Entities();
            db.Donations.Add(d);
            db.SaveChanges();

            Message m = new Message("Thank you very much for your donation!");
            return View("Result", m);

        }

        public ActionResult Result(Message msg)

        {

            return View(msg);

        }

    }
}