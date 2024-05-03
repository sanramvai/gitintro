using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTechManage.Models.ViewModels
{
    public class EmployeeListViewModel
    {
        //paging and categorizing 
        public IEnumerable<Employee> Employees { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string SelectedDepartment { get; set; }
    }
}
