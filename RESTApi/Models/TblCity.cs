//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RESTApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblCity
    {
        public int City_Id { get; set; }
        public string City { get; set; }
        public int Fk_StateId { get; set; }
    
        public virtual TblState TblState { get; set; }
    }
}
