﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyChungCu
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class qlchungcuEntities : DbContext
    {
        public qlchungcuEntities()
            : base("name=qlchungcuEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<canho> canhoes { get; set; }
        public virtual DbSet<chucvu> chucvus { get; set; }
        public virtual DbSet<dichvu> dichvus { get; set; }
        public virtual DbSet<hoadondichvu> hoadondichvus { get; set; }
        public virtual DbSet<hogiadinh> hogiadinhs { get; set; }
        public virtual DbSet<hopdong> hopdongs { get; set; }
        public virtual DbSet<khu> khus { get; set; }
        public virtual DbSet<nhanvien> nhanviens { get; set; }
        public virtual DbSet<taikhoan> taikhoans { get; set; }
        public virtual DbSet<chitietcanho> chitietcanhoes { get; set; }
        public virtual DbSet<chitiethoadon> chitiethoadons { get; set; }
    }
}
