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
    
    public partial class PaymentsLedger
    {
        public int ID { get; set; }
        public int Supplier_FK { get; set; }
        public string PaymentMethod { get; set; }
        public string Description { get; set; }
        public System.DateTime Date { get; set; }
        public double Openning { get; set; }
        public double Amount { get; set; }
        public double Remaining { get; set; }
        public int Invoice { get; set; }
        public int User_FK { get; set; }
    
        public virtual Supplier Supplier { get; set; }
        public virtual User User { get; set; }
    }
}
