using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using YogaPoseRandomizer.Models;

namespace YogaPoseRandomizer.Services
{
    public class JsonFileChakraService
    {

        public JsonFileChakraService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "PoseByChakra.json"); }
        }

        public IEnumerable<Chakra> GetChakras()
        {
            //using (var jsonFileReader = File.OpenText(JsonFileName))
            //{
            //    return JsonSerializer.Deserialize<Chakra[]>(jsonFileReader.ReadToEnd(),
            //        new JsonSerializerOptions
            //        {
            //            PropertyNameCaseInsensitive = true
            //        });
            //}

            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                IEnumerable<Chakra> ChakraList = JsonSerializer.Deserialize<Chakra[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                return ChakraList.OrderByDescending(Chakra => Chakra.ChakraNum);
            }
        }

    }
}
