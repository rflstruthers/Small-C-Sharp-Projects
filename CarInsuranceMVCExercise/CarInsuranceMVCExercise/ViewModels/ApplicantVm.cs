﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarInsuranceMVCExercise.ViewModels
{
    public class ApplicantVm
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public Nullable<decimal> Quote { get; set; }
    }
}