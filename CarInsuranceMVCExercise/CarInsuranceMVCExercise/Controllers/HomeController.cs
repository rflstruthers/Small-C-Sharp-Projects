using CarInsuranceMVCExercise.Models;
using CarInsuranceMVCExercise.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsuranceMVCExercise.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //method is called in the Index.cshtml file. Adds user input to FirstName, LastName, and EmailAddress variables
        //mapps user input from input names on Index.cshtml to string variable names passed in to SignUp method
        [HttpPost]
        public ActionResult GetCoverage(string firstName, string lastName, string emailAddress, System.DateTime dateOfBirth, 
            int carYear, string carMake, string carModel, string dui, int numberOfTickets, string fullCoverage)
        {
            //Acesses Database, adds user info to appropriate columns, returns View
            using (CarInsuranceEntities db = new CarInsuranceEntities())
            {
                //maps user input to the properties in the Applicant class
                var applicant = new Applicant
                {
                    FirstName = firstName,
                    LastName = lastName,
                    EmailAddress = emailAddress,
                    DateOfBirth = dateOfBirth,
                    CarYear = carYear,
                    CarMake = carMake.ToLower(),
                    CarModel = carModel.ToLower(),
                    DUI = dui.ToLower(),
                    NumberOfTickets = numberOfTickets,
                    FullCoverage = fullCoverage.ToLower()
                };

                //gets users age
                DateTime today = DateTime.Today;
                int age = today.Year - dateOfBirth.Year;

                decimal quote = 50m;

                //Age
                if (age < 18) { quote += 100m; }
                if (age > 18 && age < 25 || age > 100) { quote += 25m; }
                
                //Car year
                if (carYear < 2000 || carYear > 2015) { quote += 25m; }

                //Car make and model
                if (applicant.CarMake == "porsche") { quote += 25m; }
                if (applicant.CarModel == "911 carrera") { quote += 25m; }

                //DUI
                if (applicant.DUI == "y") { quote += ((quote / 100) * 25); }

                //speeding tickets
                quote += (10m * numberOfTickets);

                //Full Coverage
                if (applicant.FullCoverage == "y") { quote += ((quote / 100) * 50); }

                //Round to two decimal places, Add quote value to applicant
                quote = decimal.Round(quote, 2);
                applicant.Quote = quote;

                //Add the above object to the DB
                db.Applicants.Add(applicant);
                db.SaveChanges();

                //Add Quote to the ApplicantVm View Model
                var applicantVm = new ApplicantVm();
                applicantVm.Quote = applicant.Quote;

                return View("Quote", applicantVm);
            }
        }
    }
}