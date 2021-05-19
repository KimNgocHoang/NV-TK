using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChungCu.BLL
{
    class BLL_Nhanvien
    {
        private static BLL_Nhanvien _Instance;
        public static BLL_Nhanvien Instance
        {
            get
            {
                if (_Instance == null) _Instance = new BLL_Nhanvien();
                return _Instance;
            }
            private set { }
        }
        public IEnumerable<object> LayDSNV()
        {
            qlchungcuEntities db = new qlchungcuEntities();
            var l1 = from nv in db.nhanviens
                     join tk in db.taikhoans
                     on nv.manhanvien equals tk.manhanvien
                     select new
                     {
                         nv.manhanvien,
                         nv.tennhanvien,
                         nv.gioitinh,
                         nv.sdt,
                         nv.ngaysinh,
                         nv.cmnd,
                         nv.chucvu.tenchucvu,
                         tk.tendangnhap,
                         tk.matkhau
                     };
            return l1.ToList();
        }
        public bool Add_NV(nhanvien nv)
        {
            try
            {
                qlchungcuEntities db = new qlchungcuEntities();
                var query = db.nhanviens.Where(p => p.manhanvien == nv.manhanvien).Count();
                if (query == 0)
                {
                    db.nhanviens.Add(nv);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }
        public bool Edit_NV(nhanvien nv)
        {
            try
            {
                qlchungcuEntities db = new qlchungcuEntities();
                var query = (from p in db.nhanviens
                             where p.manhanvien == nv.manhanvien
                             select p).SingleOrDefault();
                query.manhanvien = nv.manhanvien;
                query.tennhanvien = nv.tennhanvien;
                query.ngaysinh = nv.ngaysinh;
                query.gioitinh = nv.gioitinh;
                query.sdt = nv.sdt;
                query.cmnd = nv.cmnd;
                query.machucvu = nv.machucvu;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }
        
        public void Delete_NV(int manv)
        {
            qlchungcuEntities db = new qlchungcuEntities();
            var nv = db.nhanviens.Where(p => p.manhanvien == manv).SingleOrDefault();
            db.nhanviens.Remove(nv);
            db.SaveChanges();
        }
        public IEnumerable<object> GetListNVByTen(string tennv)
        {
            qlchungcuEntities db = new qlchungcuEntities();
            var l = from nv in  db.nhanviens
                    join tk in db.taikhoans
                    on nv.manhanvien equals tk.manhanvien
                    where nv.tennhanvien.ToLower().Contains(tennv.ToLower())
                    select new
                    {
                        nv.manhanvien,
                        nv.tennhanvien,
                        nv.gioitinh,
                        nv.sdt,
                        nv.ngaysinh,
                        nv.cmnd,
                        nv.chucvu.tenchucvu,
                        tk.tendangnhap,
                        tk.matkhau
                    };
            return l.ToList();
        }
    }
}
