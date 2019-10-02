using CarInsuranceMVCExercise.Models;
using CarInsuranceMVCExercise.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsuranceMVCExercise.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()

        {
            //Entity Framework Syntax
            //Instantiate object to give access to the DB
            using (CarInsuranceEntities db = new CarInsuranceEntities())
            {
                //get applicants from DB that have a quote
                var applicants = (from c in db.Applicants
                                  where c.Quote != null
                                  select c).ToList();

                //mapping the properties from Applicant class to ApplicantVm class
                var applicantVms = new List<ApplicantVm>();
                foreach (var applicant in applicants)
                {
                    var applicantVm = new ApplicantVm();
                    applicantVm.Id = applicant.Id;
                    applicantVm.FirstName = applicant.FirstName;
                    applicantVm.LastName = applicant.LastName;
                    applicantVm.EmailAddress = applicant.EmailAddress;
                    applicantVm.Quote = applicant.Quote;
                    applicantVms.Add(applicantVm);
                }
                //pass list of applicants to view
                return View(applicantVms);
            }
        }
    }
}