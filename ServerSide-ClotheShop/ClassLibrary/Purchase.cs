//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;
    
    public partial class Purchase
    {
        public int client_id { get; set; }
        public int clothe_number { get; set; }
        public System.DateTime purchase_date { get; set; }
        public int amount { get; set; }
        public int purchase_id { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Clothe Clothe { get; set; }
    }
}