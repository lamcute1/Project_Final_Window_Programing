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
    public partial class DangKy : Form
    {
        public DangKy()
        {
            InitializeComponent();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (String.Compare(txtMatKhau.Text.ToString(), txtMatKhau2.Text.ToString()) == 0)
            {
                QLKSModel model = new QLKSModel();
                MatKhau obj = new MatKhau();
                List<MatKhau> list = obj.GetAll();

                string tenDangNhap = txtTenDangNhap.Text;
                string matKhau = txtMatKhau.Text;
                obj.username = txtTenDangNhap.Text.ToString();
                obj.password = txtMatKhau.Text.ToString();
                var check = list.Where(item => item.username.Equals(tenDangNhap)).ToList();
                if (check.Count > 0)
                {
                    MessageBox.Show("Tài khoản đã tồn tại!", "Error", MessageBoxButtons.OKCancel
                        , MessageBoxIcon.Error);
                }
                else
                {
                    model.MatKhaus.Add(obj);
                    model.SaveChanges();
                    MessageBox.Show("Đăng ký thành công!", "Notify", MessageBoxButtons.OKCancel
    , MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
                MessageBox.Show("Mật khẩu không trùng khớp!", "Error", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Error);
        }

        private void txtTenDangNhap_Enter(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text == "Tên đăng nhập")
            {
                txtTenDangNhap.Text = "";
                txtTenDangNhap.ForeColor = Color.Black;
            }
        }

        private void txtTenDangNhap_Leave(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text == "")
            {
                txtTenDangNhap.Text = "Tên đăng nhập";
                txtTenDangNhap.ForeColor = Color.Silver;
            }
        }

        private void txtMatKhau_Enter(object sender, EventArgs e)
        {
            if (txtMatKhau.Text == "Mật khẩu")
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
                txtMatKhau.Text = "Mật khẩu";
                txtMatKhau.ForeColor = Color.Silver;
            }
        }

        private void txtMatKhau2_Enter(object sender, EventArgs e)
        {
            if (txtMatKhau2.Text == "Nhập lại mật khẩu")
            {
                txtMatKhau2.UseSystemPasswordChar = true;
                txtMatKhau2.Text = "";
                txtMatKhau2.ForeColor = Color.Black;
            }
        }

        private void txtMatKhau2_Leave(object sender, EventArgs e)
        {
            if (txtMatKhau2.Text == "")
            {
                txtMatKhau2.UseSystemPasswordChar = false;
                txtMatKhau2.Text = "Nhập lại mật khẩu";
                txtMatKhau2.ForeColor = Color.Silver;
            }
        }

        private void btnHienMatKhau_MouseDown(object sender, MouseEventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = false;
        }

        private void btnHienMatKhau_MouseUp(object sender, MouseEventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = true;
        }

        private void btnHienMatKhau2_MouseDown(object sender, MouseEventArgs e)
        {
            txtMatKhau2.UseSystemPasswordChar = false;
        }

        private void btnHienMatKhau2_MouseUp(object sender, MouseEventArgs e)
        {
            txtMatKhau2.UseSystemPasswordChar = true;
        }
    }
}
