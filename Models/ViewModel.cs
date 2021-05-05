using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using WebApplication2.Helpers.Objects;
using Microsoft.AspNetCore.Http;

namespace WebApplication2.Models
{
    public class ViewModel
    {
        [Required]
        [Display(Name="Upload File")]
        public IFormFile FileAttach { get; set; }

        public List<PDF> PDFList { get; set; } 
    }
}
