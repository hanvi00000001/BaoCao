using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViThiThuHang_2119110214
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUser.Text=="hang145" && txtPass.Text == "123xyz")
            {
                new Form1().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tên hoặc mật khẩu không đúng, hãy thử lại");
                txtUser.Clear();
                txtPass.Clear();
                txtUser.Focus();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUser.Clear();
            txtPass.Clear();
            txtUser.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                // Dispose();
                Application.Exit();
            }
            
        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}
