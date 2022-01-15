using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViThiThuHang_2119110214.Model
{
    public class EmployeeBEL
    {
        public String IdEmpoyee { set; get; }

        public String Name { set; get; }
        public DateTime DateBirth { set; get; }
        public String Gender { set; get; }
        public String PlaceBirth { set; get; }
        public DepartmemtBEL Department { get; set; }

        public String De
        {
            get
            {
                return Department.Name_Department;
            }
        }
    }
}