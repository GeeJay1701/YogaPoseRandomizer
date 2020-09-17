using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YogaPoseRandomizer.Models;
using YogaPoseRandomizer.Services;

namespace YogaPoseRandomizer.Pages
{
    public class ListChakrasModel : PageModel
    {
        private readonly JsonFileChakraService ChakraService;
        public List<Chakra> ChakraList { get; private set; }

        public ListChakrasModel(JsonFileChakraService cs)
        {
            ChakraService = cs;
        }
        public void OnGet()
        {
            ChakraList = ChakraService.GetChakras().ToList<Chakra>();
        }
    }
}
