using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssist2017MVC.Models;
    // give reference to the models

namespace CommunityAssist2017MVC.Controllers
{
    public class NewPersonController : Controller
    {
        CommunityAssist2017Entities db = new CommunityAssist2017Entities();
        // This is from Data connections called CommunityAssist2017Entities (left hand side)
        // GET: NewPerson
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "LastName, FirstName, Email, Phone, PlainPassword," +
            "Apartment, Street, City, State, Zipcode")]NewPerson np)
          
        {
            Message m = new Message();
            int result = db.usp_Register(np.LastName, np.FirstName, np.Email, np.Phone, np.PlainPassword,
                np.Apartment, np.Street, np.City, np.State, np.Zipcode);
            if (result != -1)
            {
                m.MessageText = "Thanks for registering! " + np.FirstName;
            }
            else
            {
                m.MessageText = "Sorry, but something seems to have gone wrong with the registration.";
            }

            return View("Result", m);
        }

        public ActionResult Result(Message m)
        {
            return View(m);
        }
    }
}