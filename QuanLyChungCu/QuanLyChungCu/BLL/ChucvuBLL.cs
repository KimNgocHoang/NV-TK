using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChungCu.BLL
{
    class ChucvuBLL
    {
        private static ChucvuBLL _Instance;
        public static ChucvuBLL Instance
        {
            get
            {
                if (_Instance == null) _Instance = new ChucvuBLL();
                return _Instance;
            }
            private set { }
        }
        public List<chucvu> GetAllChucvu()
        {
            qlchungcuEntities db = new qlchungcuEntities();
            var l1 = db.chucvus.Select(p => p);
            return l1.ToList();
        }
    }
}
