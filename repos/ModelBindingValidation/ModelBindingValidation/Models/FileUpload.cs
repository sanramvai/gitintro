using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelBindingValidation.Models
{
    public class FileUpload
    {
        public IFormFile FileToUpload { get; set; }
    }
}
