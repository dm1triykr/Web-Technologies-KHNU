using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab1.Models.File
{
    public class UploadFileViewModel
    {
        public string Name { get; set; }
        public IFormFile File { get; set; }
    }
}
