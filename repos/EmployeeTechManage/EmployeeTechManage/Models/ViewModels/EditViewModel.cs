using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTechManage.Models.ViewModels
{
    public class EditViewModel:DropdownListViewModel
    {
        public int Id { get; set; }
        public string ExistingPath{ get; set; }
    }
}
