using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelBindingValidation.Models
{
    public class EmployeeRepository:IRepository
    {
        private Dictionary<int, Employee> empDictionary = new Dictionary<int, Employee>
        {
            [1] = new Employee
            {
                Id = 1,
                Name = "John",
                DOB = new DateTime(1980, 12, 25),
                Role = Role.Admin
            },
            [2] = new Employee
            {
                Id = 2,
                Name = "Michael",
                DOB = new DateTime(1981, 5, 13),
                Role = Role.Designer
            },
            [3] = new Employee
            {
                Id = 3,
                Name = "Rachael",
                DOB = new DateTime(1982, 11, 25),
                Role = Role.Designer
            },
            [4] = new Employee
            {
                Id = 4,
                Name = "Anna",
                DOB = new DateTime(1983, 1, 20),
                Role = Role.Manager,
                HomeAddress=new Address
                {
                    City="DowningTown",
                    Country="USA",
                    HouseNumber="54",
                    PostalCode="343434",
                    Street="East Nortington"

                }
            }
        };

        public Employee this[int id] { 
            get
            {
                return empDictionary.ContainsKey(id) ? empDictionary[id] : null;
            }
            set
            {
                empDictionary[id] = value;
            }
           
        }

        public IEnumerable<Employee> Employee => empDictionary.Values;
    }
}
