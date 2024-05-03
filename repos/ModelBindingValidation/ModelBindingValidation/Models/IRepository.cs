using System.Collections.Generic;

using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace ModelBindingValidation.Models
{
    public interface IRepository
    {
        IEnumerable<Employee> Employee { get; }
        Employee this[int id] {get; set; }
    }
}
