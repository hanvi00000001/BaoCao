using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViThiThuHang_2119110214.DAL;
using ViThiThuHang_2119110214.Model;

namespace ViThiThuHang_2119110214.BAL
{
    public class DepartmentBAL
    {
        DepartmemtDAL dal = new DepartmemtDAL();
        public List<DepartmemtBEL> ReadAreaList()
        {
            List<DepartmemtBEL> lstDe = dal.ReadAreaList();
            return lstDe;
        }
    }
}
