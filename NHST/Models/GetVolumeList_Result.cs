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
    
    public partial class GetVolumeList_Result
    {
        public int ID { get; set; }
        public string WareHouseFromName { get; set; }
        public string WareHouseToName { get; set; }
        public Nullable<double> VolumeFrom { get; set; }
        public Nullable<double> VolumeTo { get; set; }
        public Nullable<double> ValueVolume { get; set; }
        public string ShippingTypeName { get; set; }
        public Nullable<bool> IsHelpMoving { get; set; }
        public Nullable<int> TotalRow { get; set; }
    }
}