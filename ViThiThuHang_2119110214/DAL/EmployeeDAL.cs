using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ViThiThuHang_2119110214;
using System.Data;
using ViThiThuHang_2119110214.Model;
using ViThiThuHang_2119110214.BAL;
using Microsoft.AspNet.SignalR.Infrastructure;

namespace ViThiThuHang_2119110214.DAL
{
    public class EmployeeDAL : DBConnection
    {
        public List<EmployeeBEL> ReadCustomer()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("selectEmployee", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            List<EmployeeBEL> lstEmployee = new List<EmployeeBEL>();
            EmployeeDAL employee = new EmployeeDAL();
            DepartmemtDAL departmemt = new DepartmemtDAL();
            while (reader.Read())
            {
                EmployeeBEL Empl = new EmployeeBEL();
                Empl.IdEmpoyee = reader["IdEmployee"].ToString();
                Empl.Name = reader["Name"].ToString();
                Empl.DateBirth = DateTime.Parse(reader["DateBirth"].ToString());
                Empl.Gender = reader["Gender"].ToString();
                Empl.PlaceBirth = reader["PlaceBirth"].ToString();
                Empl.Department = departmemt.ReadArea(int.Parse(reader["IdDepartment"].ToString()));
                lstEmployee.Add(Empl);

            }
            conn.Close();
            return lstEmployee;
        }
        public void NewEmployeeBEL(EmployeeBEL empl)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "NewEmployee";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                cmd.Parameters.Add("@IdEmployee", SqlDbType.NVarChar).Value = empl.IdEmpoyee;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = empl.Name;
                cmd.Parameters.Add("@DateBirth", SqlDbType.Date).Value = empl.DateBirth;
                cmd.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = empl.Gender;
                cmd.Parameters.Add("@PlaceBirth", SqlDbType.NVarChar).Value = empl.PlaceBirth;
                cmd.Parameters.Add("@IdDepartment", SqlDbType.Int).Value = empl.Department.IdDepartment;
                cmd.ExecuteNonQuery();
                conn.Close();

                Console.WriteLine("Thêm thành công !!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Vui lòng kiểm tra lại !!!" + e);
            }
            finally
            {
                conn.Close();
            }
        }

        public void EditEmployeeBEL(EmployeeBEL empl)
        {
            SqlConnection con = CreateConnection();
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "EditEmployee";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@IdEmployee", SqlDbType.NVarChar).Value = empl.IdEmpoyee;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = empl.Name;
                cmd.Parameters.Add("@DateBirth", SqlDbType.Date).Value = empl.DateBirth;
                cmd.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = empl.Gender;
                cmd.Parameters.Add("@PlaceBirth", SqlDbType.NVarChar).Value = empl.PlaceBirth;
                cmd.Parameters.Add("@IdDepartment", SqlDbType.Int).Value = empl.Department.IdDepartment;
            
                cmd.ExecuteNonQuery();
                con.Close();

                Console.WriteLine("Sửa thành công!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Vui lòng kiểm tra lại !" + e);
            }
            finally
            {
                con.Close();
            }
        }

        public void DeletEmployeeBEL(EmployeeBEL empl)
        {

            SqlConnection con = CreateConnection();
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "DeleteEmployee";
                cmd.CommandType = CommandType.StoredProcedure;
              

                cmd.Parameters.Add("@IdEmployee", SqlDbType.NVarChar).Value = empl.IdEmpoyee;


                cmd.ExecuteNonQuery();

                con.Close();

                Console.WriteLine("Xoá thành công!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Vui lòng kiểm tra lại!" + e);
            }
            finally
            {
                con.Close();
            }
        }

    }
}
