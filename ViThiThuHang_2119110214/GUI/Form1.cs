using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViThiThuHang_2119110214.BAL;
using ViThiThuHang_2119110214.DAL;
using ViThiThuHang_2119110214.Model;

namespace ViThiThuHang_2119110214
{
    public partial class Form1 : Form
    {
        EmployeeBAL employeeBAL = new EmployeeBAL();
        DepartmentBAL departmentBAL = new DepartmentBAL();
        public Form1()
        {
            InitializeComponent();
        }

        private void Res()
        {
        }
        private void button5_Click(object sender, EventArgs e)//reset
        {
            
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            DataGridViewRow row = dgvNhanVien.Rows[idx];
            if (row.Cells[0].Value != null)
            {
                tbId.Text = row.Cells[0].Value.ToString();
                tbName.Text = row.Cells[1].Value.ToString();
                dtBirth.Text = row.Cells[2].Value.ToString();
                tbGender.Text = row.Cells[3].Value.ToString();
                tbPlaceBirth.Text = row.Cells[4].Value.ToString();
                cbDepartment.Text = row.Cells[5].Value.ToString();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<EmployeeBEL> lstEmploy = employeeBAL.ReadCustomer();
            foreach(EmployeeBEL Empl in lstEmploy)
            {
                dgvNhanVien.Rows.Add(Empl.IdEmpoyee, Empl.Name, Empl.DateBirth, Empl.Gender, Empl.PlaceBirth, Empl.Department.Name_Department);
            }
            List<DepartmemtBEL> lstDe = departmentBAL.ReadAreaList();
            foreach(DepartmemtBEL de in lstDe)
            {
                cbDepartment.Items.Add(de);
            }
            cbDepartment.DisplayMember = "Name_department";
        }

        private void button4_Click(object sender, EventArgs e)//add
        {
            if (checkLink())
            {
                EmployeeBEL empl = new EmployeeBEL();
                empl.IdEmpoyee = tbId.Text;
                empl.Name = tbName.Text;
                empl.DateBirth = DateTime.Parse(dtBirth.Value.Date.ToString());
                empl.Gender = tbGender.Text;
                empl.PlaceBirth = tbPlaceBirth.Text;
                empl.Department = (DepartmemtBEL)cbDepartment.SelectedItem;

               employeeBAL.NewEmployeeBEL(empl);
                dgvNhanVien.Rows.Add(empl.IdEmpoyee, empl.Name, empl.DateBirth, empl.Gender, empl.PlaceBirth, empl.Department.Name_Department);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            EmployeeBEL empl = new EmployeeBEL();
            empl.IdEmpoyee = tbId.Text;
            empl.Name = tbName.Text;
            empl.DateBirth = DateTime.Parse(dtBirth.Value.Date.ToString());
            empl.Gender = tbGender.Text;
            empl.PlaceBirth = tbPlaceBirth.Text;
            empl.Department = (DepartmemtBEL)cbDepartment.SelectedItem;
            employeeBAL.DeleteEmployee(empl);
            int idx = dgvNhanVien.CurrentCell.RowIndex;
            dgvNhanVien.Rows.RemoveAt(idx);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (checkLink())
            {
                DataGridViewRow row = dgvNhanVien.CurrentRow;

                EmployeeBEL empl = new EmployeeBEL();
                empl.IdEmpoyee = tbId.Text;
                empl.Name = tbName.Text;
                empl.DateBirth = DateTime.Parse(dtBirth.Value.Date.ToString());
                empl.Gender = tbGender.Text;
                empl.PlaceBirth = tbPlaceBirth.Text;
                empl.Department = (DepartmemtBEL)cbDepartment.SelectedItem;
                employeeBAL.EditEmployee(empl);
                row.Cells[0].Value = empl.IdEmpoyee;
                row.Cells[1].Value = empl.Name;
                row.Cells[2].Value = empl.DateBirth;
                row.Cells[3].Value = empl.Gender;
                row.Cells[4].Value = empl.PlaceBirth;
                row.Cells[5].Value = empl.Department;

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Bạn có chắc muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Dispose();
            }
        }
        public bool checkLink() {
            if (string.IsNullOrWhiteSpace(tbId.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (string.IsNullOrWhiteSpace(tbPlaceBirth.Text))
            {
                MessageBox.Show("Vui lòng nhập Nơi Sinh", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (string.IsNullOrWhiteSpace(dtBirth.Text))
            {
                MessageBox.Show("Vui lòng nhập Ngày Sinh", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (string.IsNullOrWhiteSpace(tbGender.Text))
            {
                MessageBox.Show("Vui lòng nhập Giới Tính", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (string.IsNullOrWhiteSpace(cbDepartment.Text))
            {
                MessageBox.Show("Vui lòng nhập Đơn Vị", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }
    }
}
