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
    
    public partial class attachment
    {
        public int id { get; set; }
        public Nullable<int> articles_id { get; set; }
        public string filename { get; set; }
        public string content_type { get; set; }
        public Nullable<double> size { get; set; }
        public string path { get; set; }
        public Nullable<int> attachment_types_id { get; set; }
    
        public virtual article article { get; set; }
        public virtual attachment_types attachment_types { get; set; }
    }
}
