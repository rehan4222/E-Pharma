//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace POS
{
    using System;
    using System.Collections.Generic;
    
    public partial class rpt_ProfitLoss
    {
        public int ID { get; set; }
        public string Date { get; set; }
        public string Product { get; set; }
        public double TotalPurchase { get; set; }
        public int Quantity { get; set; }
        public double TotalSale { get; set; }
        public double Profit { get; set; }
    }
}