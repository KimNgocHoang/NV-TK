//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class hoadondichvu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public hoadondichvu()
        {
            this.chitiethoadons = new HashSet<chitiethoadon>();
        }
    
        public int mahoadon { get; set; }
        public Nullable<int> macanho { get; set; }
        public Nullable<int> manhanvien { get; set; }
        public double tongtien { get; set; }
        public bool dathanhtoan { get; set; }
        public Nullable<System.DateTime> ngaythanhtoan { get; set; }
    
        public virtual canho canho { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chitiethoadon> chitiethoadons { get; set; }
        public virtual nhanvien nhanvien { get; set; }
    }
}
