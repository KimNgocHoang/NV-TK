using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChungCu.View
{
    public partial class Form_QuanLy : Form
    {
        public Form_QuanLy()
        {
            InitializeComponent();
        }
        #region Function
        private bool CheckExistForm(string name)
        {
            bool check = false;
            foreach(Form i in this.MdiChildren)
            {
                if(i.Name == name)
                {
                    check = true;
                    break;
                }
            }
            return check;
        }
        private void ActiveChildForm(string name)
        {
            foreach (Form i in this.MdiChildren)
            {
                if (i.Name == name)
                {
                    i.Activate();
                    break;
                }
            }
        }
        private void SetbtnColor(Button btn)
        {
            lb_Tieude.Text = btn.Text;
            foreach(Control i in pnl_btnChucNang.Controls)
            {
                i.BackColor = pnl_btnChucNang.BackColor;
            }
            btn_help.BackColor = pnl_btnChucNang.BackColor;
            btn.BackColor = Color.Fuchsia;
        }
        #endregion
        #region Event
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void btn_menu_Click(object sender, EventArgs e)
        {
            panel1.Width = (panel1.Width == 375) ? 50 : 375;
            panel5.Width = (panel5.Width == 0) ? 325 : 0;
        }

        private void btn_hide_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_ChoThue_Click(object sender, EventArgs e)
        {
            SetbtnColor(sender as Button);
            if (!CheckExistForm("Form_ChoThue"))
            {
                Form_ChoThue f = new Form_ChoThue();
                f.MdiParent = this;
                f.StartPosition = FormStartPosition.Manual;
                f.Width = 1156;
                f.Height = 802;
                f.Show();
            }
            else ActiveChildForm("Form_ChoThue");
        }
        private void btn_Dichvu_Click(object sender, EventArgs e)
        {
            SetbtnColor(sender as Button);
            if (!CheckExistForm("Form_Dichvu"))
            {
                Form_Dichvu f = new Form_Dichvu();
                f.MdiParent = this;
                f.StartPosition = FormStartPosition.Manual;
                f.Width = 1156;
                f.Height = 802;
                f.Show();
            }
            else ActiveChildForm("Form_Dichvu");
        }

        private void btn_Hopdong_Click(object sender, EventArgs e)
        {
            SetbtnColor(sender as Button);
            if (!CheckExistForm("Form_Hopdong"))
            {
                Form_Hopdong f = new Form_Hopdong();
                f.MdiParent = this;
                f.StartPosition = FormStartPosition.Manual;
                f.Width = 1156;
                f.Height = 802;
                f.Show();
            }
            else ActiveChildForm("Form_Hopdong");
        }

        private void btn_help_Click(object sender, EventArgs e)
        {
            SetbtnColor(sender as Button);
        }
        private void btn_Nhanvien_Click(object sender, EventArgs e)
        {
            SetbtnColor(sender as Button);
            if (!CheckExistForm("Form_Nhanvien"))
            {
                Form_Nhanvien f = new Form_Nhanvien();
                f.MdiParent = this;
                f.StartPosition = FormStartPosition.Manual;
                f.Width = 1156;
                f.Height = 802;
                f.Show();
            }
            else ActiveChildForm("Form_Nhanvien");
        }

        private void btn_Canho_Click(object sender, EventArgs e)
        {
            SetbtnColor(sender as Button);
            if (!CheckExistForm("Form_Canho"))
            {
                Form_Hopdong f = new Form_Hopdong();
                f.MdiParent = this;
                f.StartPosition = FormStartPosition.Manual;
                f.Width = 1156;
                f.Height = 802;
                f.Show();
            }
            else ActiveChildForm("Form_Canho");
        }

        private void btn_Thongtin_Click(object sender, EventArgs e)
        {
            SetbtnColor(sender as Button);
            if (!CheckExistForm("Form_Thongtin"))
            {
                Form_Hopdong f = new Form_Hopdong();
                f.MdiParent = this;
                f.StartPosition = FormStartPosition.Manual;
                f.Width = 1156;
                f.Height = 802;
                f.Show();
            }
            else ActiveChildForm("Form_Thongtin");
        }




        #endregion


    }
}
