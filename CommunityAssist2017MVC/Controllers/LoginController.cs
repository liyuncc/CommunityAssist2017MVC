using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssist2017MVC.Models;
namespace CommunityAssist2017MVC.Controllers
{
    public class LoginController : Controller
    {
        CommunityAssist2017Entities db = new CommunityAssist2017Entities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Email, PlainPassword")]LoginClass lc)

        {

            int results = db.usp_Login(lc.Email, lc.PlainPassword);
            int revKey = 0;
            Message msg = new Message();

            if (results != -1)
            {
                var pkey = (from r in db.People

                            where r.PersonEmail.Equals(lc.Email)

                            select r.PersonKey).FirstOrDefault();

                revKey = (int)pkey;

                Session["PersonKey"] = revKey;

                msg.MessageText = "Welcome, " + lc.Email;
            }
            else
                msg.MessageText = "Invalid Login. Please try again or register.";
            return View("Result", msg);
        }
        public ActionResult Result(Message msg)
        {
            return View(msg);
        }
    }
}