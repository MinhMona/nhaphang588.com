//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NHST.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_SmallPackage1
    {
        public int ID { get; set; }
        public Nullable<int> BigPackageID { get; set; }
        public Nullable<System.DateTime> SendDate { get; set; }
        public string PackageCode { get; set; }
        public string BarcodeURL { get; set; }
        public Nullable<int> UID { get; set; }
        public string UserPhone { get; set; }
        public Nullable<double> Weight { get; set; }
        public Nullable<int> Place { get; set; }
        public Nullable<int> StatusReceivePackage { get; set; }
        public Nullable<int> StatusPayment { get; set; }
        public string Note { get; set; }
        public string NoteCustomer { get; set; }
        public Nullable<bool> IsPayCash { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}