using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YogaPoseRandomizer.Models;
using YogaPoseRandomizer.Services;

namespace YogaPoseRandomizer.Pages
{
    public class ClassPoseSelectModel : PageModel
    {

        private readonly JsonFileChakraService ChakraService;
        public List<Chakra> ChakraList { get; private set; }

        [BindProperty]
        public List<Pose> PoseList { get; set; }

        public ClassPoseSelectModel (JsonFileChakraService cs)
        {
            ChakraService = cs;
        }
        public void OnGet()
        {
            ChakraList = ChakraService.GetChakras().ToList<Chakra>();

            PoseList = new List<Pose>();
            int selectedPose;
            Random rnd = new Random();

            //Cycle thru each of the Chakras and randomly select a pose the current Chakra
            foreach (Chakra ch in ChakraList)
            {
                //Generate a random number between 1 and the number of poses
                selectedPose = rnd.Next(0, ch.Poses.Length - 1);
                //Add the pose to the list
                PoseList.Add(ch.Poses[selectedPose]);
            }
        }

        public JsonResult OnGetPoseImage(int index, String poseName, String chakraId)
        {
            //Retrieve the entire chakra list
            List<Chakra> ChakraList = ChakraService.GetChakras().ToList<Chakra>();

            //Using the index value and pose name retrieve the Pose.
            Pose p = ChakraList.Where(x => x.Id == chakraId).FirstOrDefault().Poses.Where(x => x.Name == poseName).FirstOrDefault();
            //Pose p = ChakraList[index].Poses.Where(x => x.Name == poseName).FirstOrDefault();

            return new JsonResult(p);
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                //Save the list of poses for later use.
                TempData["PoseList"] = JsonSerializer.Serialize<Pose[]>(PoseList.ToArray());

                return RedirectToPage("ClassSettings");
            }

            return Page();
        }
    }
}
