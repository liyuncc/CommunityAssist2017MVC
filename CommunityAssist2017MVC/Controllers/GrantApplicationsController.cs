using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssist2017MVC.Models;

namespace CommunityAssist2017MVC.Controllers
{
    public class GrantApplicationsController : Controller
    {
        // GET: GrantApplications

        CommunityAssist2017Entities db = new CommunityAssist2017Entities();
        public ActionResult Index()
        {
            if (Session["PersonKey"] == null)
            {
                Message msg = new Message();
                msg.MessageText = "You must be logged in to apply for grants.";
                return RedirectToAction("Result", msg);
            }
            ViewBag.GrantType = new SelectList(db.GrantTypes, "GrantTypeKey", "GrantTypeName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "PersonKey, GrantApplicationDate, GrantTypeKey," +
            "GrantApplicationRequestAmount, GrantApplicationReason, GrantApplicationStatusKey")] GrantApplication a)
        {
            try
            {
                a.PersonKey = (int)Session["PersonKey"];
                a.GrantAppicationDate = DateTime.Now;
                a.GrantApplicationStatusKey = (int)1;
                db.GrantApplications.Add(a);
                db.SaveChanges();
                Message m = new Message();
                m.MessageText = "Thank you for applying!";
                return RedirectToAction("Result", m);
            }
            catch (Exception e)
            {
                Message m = new Message();
                m.MessageText = e.Message;
                return RedirectToAction("Result", m);
            }
        }

        public ActionResult Result (Message msg)
        {
            return View(msg);
        }
    }
}