﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.Models
{
    public interface IDataSource
    {
        public IEnumerable<Product> products { get;}
    }
}
