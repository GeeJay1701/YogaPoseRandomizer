using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YogaPoseRandomizer.Models;

namespace YogaPoseRandomizer.Pages
{
    public class ClassSettingsModel : PageModel
    {
        [BindProperty, Required, Display(Name = "Pose Duration (minutes)"), Range(1, 5, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int PoseDuration { get; set; } = 4;

        [BindProperty, Required, Display(Name = "Duration between poses (seconds)"), Range(15, 60, ErrorMessage = "Value must be between {1} and {2}.")]
        public int PrepDuration { get; set; } = 30;

        [BindProperty, Required, Display(Name = "Shavasana")]
        public string Shavasana { get; set; } = "None";

        public string[] ShavasanaOptions = new[] { "Before Class", "After Class", "None" };

        [BindProperty, Display(Name = "Duration(minutes)"), Range(0, 30, ErrorMessage = "Value for {0} may not exceed {2} minutes.")]
        public int ShavasanaDuration { get; set; } = 0;

        public void OnGet()
        {
        }
        public ActionResult OnPost()
        {

            if (ModelState.IsValid)
            {
                //Retrieve the PoseList from TempData
                var x = TempData["PoseList"] as String;
                Pose[] p = JsonSerializer.Deserialize<Pose[]>(x);

                //Create a new instance of YogaClass and store all the details of
                //the class.
                YogaClass yc = new YogaClass
                {
                    PoseDuration = PoseDuration,
                    PrepDuration = PrepDuration,
                    Shavasana = Shavasana,
                    ShavasanaDuration = ShavasanaDuration,
                    PoseList = p
                };

                TempData["YogaClass"] = yc.ToString();

                return RedirectToPage("ClassConfirmation");
            }
            return Page();
        }
    }
}
