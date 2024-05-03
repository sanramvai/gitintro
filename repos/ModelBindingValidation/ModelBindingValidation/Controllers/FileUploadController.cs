using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ModelBindingValidation.Controllers
{
    public class FileUploadController : Controller
    {
        public IWebHostEnvironment Environment { get; set; }
        public FileUploadController(IWebHostEnvironment env)
        {
            Environment = env;
        }
        public IActionResult Index() => View();
        [HttpPost]
        public IActionResult Index(IFormFile fileToUpload)
        {
            string filepath=Path.Combine(Environment.WebRootPath+"/Images/"+ fileToUpload.FileName);
            using (var stream = new FileStream(filepath, FileMode.Create))
            {
                stream.CopyToAsync(stream);
            }
            return Ok();
        }
    }
}
