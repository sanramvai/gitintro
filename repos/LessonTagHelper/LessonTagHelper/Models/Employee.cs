using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonTagHelper.Models
{
    public class Friend
    {
        public string Name { get; set; }
    }

    public class Employee
    {
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public string Profile { get; set; }
        public List<Friend> Friends { get; set; }
       
    }
}
