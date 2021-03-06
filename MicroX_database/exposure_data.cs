//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MicroX_database
{
    using System;
    using System.Collections.Generic;
    
    public partial class exposure_data
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public exposure_data()
        {
            this.errors = new HashSet<error>();
        }
    
        public long exp_id { get; set; }
        public string tube_nr { get; set; }
        public System.DateTime exp_ts { get; set; }
        public int shot_count { get; set; }
        public Nullable<int> pre_kv { get; set; }
        public Nullable<float> pre_mas { get; set; }
        public Nullable<int> pre_ia { get; set; }
        public Nullable<int> pre_ms { get; set; }
        public Nullable<int> pre_ic { get; set; }
        public Nullable<int> pre_vgc { get; set; }
        public Nullable<int> pre_vf { get; set; }
        public int post_kv { get; set; }
        public float post_mas { get; set; }
        public Nullable<float> post_ia { get; set; }
        public Nullable<int> post_ms { get; set; }
        public Nullable<float> post_ic { get; set; }
        public Nullable<int> post_vgc { get; set; }
        public Nullable<int> post_vf_xrs { get; set; }
        public Nullable<int> post_vf_tube { get; set; }
        public Nullable<float> post_if_pre { get; set; }
        public Nullable<float> post_if_after { get; set; }
        public Nullable<float> post_tshot { get; set; }
        public Nullable<float> post_tavg { get; set; }
        public Nullable<int> post_rg { get; set; }
        public Nullable<int> post_vz { get; set; }
        public Nullable<float> post_dap { get; set; }
    
        public virtual tube_data tube_data { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<error> errors { get; set; }
    }
}
