﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MicroXEntities : DbContext
    {
        public MicroXEntities()
            : base("name=MicroXEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<dose_measurements> dose_measurements { get; set; }
        public virtual DbSet<eol_shot> eol_shot { get; set; }
        public virtual DbSet<error> errors { get; set; }
        public virtual DbSet<exposure_data> exposure_data { get; set; }
        public virtual DbSet<fss_data> fss_data { get; set; }
        public virtual DbSet<system> systems { get; set; }
        public virtual DbSet<tester> testers { get; set; }
        public virtual DbSet<tube_data> tube_data { get; set; }
        public virtual DbSet<tube_system> tube_system { get; set; }
    }
}
