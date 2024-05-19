using System;
using SQLite;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography.X509Certificates;

namespace FinalProject
{
    public class table
    {
        [PrimaryKey]
        public int ReferenceNumber { get; set; }
        public string Name {  get; set; }
        public string Date { get; set; }
        public string Type { get; set; }
        public double PrincipalAmount {  get; set; }
        public double Terms {  get; set; }
        public double Balance {  get; set; }
        public double ServiceFee {  get; set; }
        public double FilingFee { get; set; }
        public double InsuranceFee {  get; set; }
        public double CapitalRetention { get; set; }
        public double SavingsRetention {  get; set; }
        public double MonthlyAmortization {  get; set; }
        public double PrincipalMonthlyPay {  get; set; }
        public double InterestMonthlyPay { get; set; }
        public double Net {  get; set; }
        public double TotalInterestEarned {  get; set; }
    }
}
