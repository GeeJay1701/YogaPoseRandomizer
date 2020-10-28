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

        public String Sequence { get; private set; }

        [BindProperty]
        public List<Pose> PoseList { get; set; }

        public ClassPoseSelectModel (JsonFileChakraService cs)
        {
            ChakraService = cs;
        }
        public void OnGet(String sequence)
        {
            // Retrieve the list of Chakras. Already sorted by ChakraNum (Desending) root-to-crown
            ChakraList = ChakraService.GetChakras().ToList<Chakra>();

            //Change the Chakra sequence if needed.
            switch (sequence)
            {
                case "root-to-crown":
                    Sequence = "Root to Crown";
                    break;
                case "crown-to-root":
                    Sequence = "Crown to Root";
                    ChakraList = ChakraList.OrderBy(Chakra => Chakra.ChakraNum).ToList();
                    break;
                default:
                    break;
            }

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

        public JsonResult OnGetPoseImage(String poseName, String chakraId)
        {
            //Retrieve the entire chakra list
            List<Chakra> ChakraList = ChakraService.GetChakras().ToList<Chakra>();

            //Using the Chakra Id and pose name retrieve the Pose.
            Pose p = ChakraList.Where(x => x.Id == chakraId).FirstOrDefault().Poses.Where(x => x.Name == poseName).FirstOrDefault();

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
