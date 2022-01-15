using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViThiThuHang_2119110214.DAL;
using ViThiThuHang_2119110214.Model;

namespace ViThiThuHang_2119110214.BAL
{
    public class EmployeeBAL
    {
        EmployeeDAL dal = new EmployeeDAL();
        
        public List<EmployeeBEL> ReadCustomer()
        {

            List<EmployeeBEL> lstEmpl = dal.ReadCustomer();
            return lstEmpl;
        }
        public void NewEmployeeBEL(EmployeeBEL empl)
        {
            dal.NewEmployeeBEL(empl);
        }
        public void EditEmployee(EmployeeBEL empl)
        {
            dal.EditEmployeeBEL(empl);

        }
        public void DeleteEmployee(EmployeeBEL empl)
        {
            dal.DeletEmployeeBEL(empl);
        }

        internal static void DeletEmployeeBEL(EmployeeBEL empl)
        {
            throw new NotImplementedException();
        }

        internal static void EditEmployeeBEL(EmployeeBEL empl)
        {
            throw new NotImplementedException();
        }
        

    }
}
