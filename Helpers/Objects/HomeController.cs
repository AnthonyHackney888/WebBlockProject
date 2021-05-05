using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Helpers.Objects
{
    public class PDF 
    {

        /// <summary>
        /// Gets the PDF ID
        /// </summary>
        public int FileID{ get;set; }
        /// <summary>
        /// Gets or sets files name
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// gets or sets file extension
        /// </summary>
        public string ContentType { get; set; }
    }
}
