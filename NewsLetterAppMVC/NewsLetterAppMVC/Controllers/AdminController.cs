using NewsLetterAppMVC.Models;
using NewsLetterAppMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsLetterAppMVC.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            //Entity Framework Syntax
            //Instantiate object to give access to the DB
            using (NewsletterEntities db = new NewsletterEntities())
            {
                ////assign the class that represents the DB table SignUps to signups variable, 
                ////but only the entries in the table that have a null value in their Removed column
                //var signups = db.SignUps.Where(x => x.Removed == null).ToList();

                //same as above code but uses Linq. Gets entries from SignUps table that have a Removed value of Null
                var signups = (from c in db.SignUps
                               where c.Removed == null
                               select c).ToList();

                //mapping the properties from NewsletterSignUp class to SignupVm class
                var signupVms = new List<SignupVm>();
                foreach (var signup in signups)
                {
                    var signupVm = new SignupVm();
                    signupVm.Id = signup.Id;
                    signupVm.FirstName = signup.FirstName;
                    signupVm.LastName = signup.LastName;
                    signupVm.EmailAddress = signup.EmailAddress;
                    signupVms.Add(signupVm);
                }
                return View(signupVms);
            }

            //////////Below was used before Entity Framework was added
            //string queryString = @"SELECT Id, FirstName, LastName, EmailAddress, SocialSecurityNumber FROM SignUps";
            //List<NewsletterSignUp> signups = new List<NewsletterSignUp>();

            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    SqlCommand command = new SqlCommand(queryString, connection);
            //    connection.Open();
            //    SqlDataReader reader = command.ExecuteReader();

            //    while (reader.Read())
            //    {
            //        var signup = new NewsletterSignUp();
            //        signup.Id = Convert.ToInt32(reader["Id"]);
            //        signup.FirstName = reader["FirstName"].ToString();
            //        signup.LastName = reader["LastName"].ToString();
            //        signup.EmailAddress = reader["EmailAddress"].ToString();
            //        signup.SocialSecurityNumber = reader["SocialSecurityNumber"].ToString();
            //        signups.Add(signup);
            //    }
            //}
        } 

        //method to add a timestamp to Removed column in DB (which means the person is unsubscribed from the newsletter)
        public ActionResult Unsubscribe(int Id)
        {
            using (NewsletterEntities db = new NewsletterEntities())
            {
                //search DB for record with desired Id
                var signup = db.SignUps.Find(Id);
                //Add timestamp to Removed column for the desired record
                signup.Removed = DateTime.Now;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}