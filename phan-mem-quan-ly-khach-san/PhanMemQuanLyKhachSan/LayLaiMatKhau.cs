using PhanMemQuanLyKhachSan.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PhanMemQuanLyKhachSan
{
    public partial class LayLaiMatKhau : Form
    {
        public LayLaiMatKhau()
        {
            InitializeComponent();
        }


        private void txtTenDangNhap_Leave(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text == "")
            {
                txtTenDangNhap.Text = "Tên đăng nhập";
                txtTenDangNhap.ForeColor = Color.Silver;
            }
        }

        private void txtTenDangNhap_Enter(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text == "Tên đăng nhập")
            {
                txtTenDangNhap.Text = "";
                txtTenDangNhap.ForeColor = Color.Black;
            }
        }

        private void txtMatKhau_Enter(object sender, EventArgs e)
        {
            if (txtMatKhau.Text == "Mật khẩu mới")
            {
                txtMatKhau.UseSystemPasswordChar = true;
                txtMatKhau.Text = "";
                txtMatKhau.ForeColor = Color.Black;
            }
        }

        private void txtMatKhau_Leave(object sender, EventArgs e)
        {
            if (txtMatKhau.Text == "")
            {
                txtMatKhau.UseSystemPasswordChar = false;
                txtMatKhau.Text = "Mật khẩu mới";
                txtMatKhau.ForeColor = Color.Silver;
            }
        }

        private void btnHienMatKhau_MouseUp(object sender, MouseEventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = true;
        }

        private void btnHienMatKhau_MouseDown(object sender, MouseEventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = false;
        }

        private void txtMatKhauMoi_Enter(object sender, EventArgs e)
        {
            if (txtMatKhauMoi.Text == "Nhập lại mật khẩu mới")
            {
                txtMatKhauMoi.UseSystemPasswordChar = true;
                txtMatKhauMoi.Text = "";
                txtMatKhauMoi.ForeColor = Color.Black;
            }
        }

        private void txtMatKhauMoi_Leave(object sender, EventArgs e)
        {
            if (txtMatKhauMoi.Text == "")
            {
                txtMatKhauMoi.UseSystemPasswordChar = false;
                txtMatKhauMoi.Text = "Nhập lại mật khẩu mới";
                txtMatKhauMoi.ForeColor = Color.Silver;
            }
        }

        private void btnHienMatKhau2_MouseDown(object sender, MouseEventArgs e)
        {
            this.txtMatKhauMoi.UseSystemPasswordChar = false;
        }

        private void btnHienMatKhau2_MouseUp(object sender, MouseEventArgs e)
        {
            this.txtMatKhauMoi.UseSystemPasswordChar = true;
        }


        public static MatKhau GetMatKhau(string name)
        {
            QLKSModel context = new QLKSModel();
            return context.MatKhaus.Where(p => p.username == name).FirstOrDefault();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {

            if (String.Compare(this.txtMatKhau.Text.ToString(), this.txtMatKhauMoi.Text.ToString()) == 0)
            {
                string tenDangNhap = txtTenDangNhap.Text.ToString();
                QLKSModel context = new QLKSModel();
                MatKhau obj = new MatKhau();
                List<MatKhau> list = obj.GetAll();
                var check = list.Where(item => item.username.Equals(tenDangNhap)).FirstOrDefault();
                
                if (check != null)
                {
                    MatKhau val = context.MatKhaus.Where(d => d.username == tenDangNhap).First();
                    val.password = txtMatKhau.Text.ToString();
                    context.SaveChanges();
                    MessageBox.Show("Cập nhật mật khẩu thành công!", "Notify", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Information);
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Không tồn tại tài khoản!", "Error", MessageBoxButtons.OKCancel,
    MessageBoxIcon.Error);
                }

            }

        }
    }
}

