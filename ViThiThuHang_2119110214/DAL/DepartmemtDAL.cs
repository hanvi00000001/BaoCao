using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ViThiThuHang_2119110214.DAL;
using ViThiThuHang_2119110214.Model;

namespace ViThiThuHang_2119110214.DAL
{
    public class DepartmemtDAL : DBConnection
    {
        public List<DepartmemtBEL> ReadAreaList()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Department", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<DepartmemtBEL> lstDepartment = new List<DepartmemtBEL>();
            while (reader.Read())
            {
                DepartmemtBEL Depart = new DepartmemtBEL();
                Depart.IdDepartment = int.Parse(reader["IdDepartment"].ToString());
                Depart.Name_Department = reader["Name_department"].ToString();
                lstDepartment.Add(Depart);
            }
            conn.Close();
            return lstDepartment;
        }
        public DepartmemtBEL ReadArea(int id)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Department where IdDepartment=" + id.ToString(), conn);
            DepartmemtBEL Department = new DepartmemtBEL();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows && reader.Read())
            {
                Department.IdDepartment = int.Parse(reader["IdDepartment"].ToString());
                Department.Name_Department = reader["name_department"].ToString();
            }
            conn.Close();
            return Department;
        }
    }
}
