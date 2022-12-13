﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement_WPF.Model
{
    public class LoanDetail
    {
        public int LoanId { get; set; }
        public string UserName { get; set; }
        public string LoanType { get; set; }
        public double LoanAmount { get; set; }
        public DateTime LoanDate { get; set; }
        public float RateOfInterest { get; set; }
        public int LoanDuration { get; set; }
        public string Status { get; set; }
    }
}
