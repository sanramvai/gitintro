using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTechManage.Models.ViewModels
{
    public class DepartmentSelectViewModel
    {
        public IEnumerable<string> DepartmentList { set; get; }
        public string selectedDepartment { set; get; }
    }
}
