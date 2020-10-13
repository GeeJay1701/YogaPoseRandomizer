using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace YogaPoseRandomizer.Pages
{
    public class ClassShowModel : PageModel
    {
        public IWebHostEnvironment WebHostEnvironment { get; }
        public ClassShowModel(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }
        public void OnGet()
        {
        }
    }
}
