using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace YogaPoseRandomizer.Models
{
    public class Chakra
    {
        public string Id { get; set; }
        public int ChakraNum { get; set; }
        public string Location { get; set; }
        public string Element { get; set; }
        public string Benefit { get; set; }
        public string Picture { get; set; }
        public Pose[] Poses { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Chakra>(this);
    }

    public class Pose
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
    }
}
