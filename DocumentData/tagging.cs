//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DocumentData
{
    using System;
    using System.Collections.Generic;
    
    public partial class tagging
    {
        public int id { get; set; }
        public int articles_id { get; set; }
        public int tags_id { get; set; }
    
        public virtual article article { get; set; }
        public virtual tag tag { get; set; }
    }
}
