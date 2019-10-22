using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogNames.Models
{
    public class Name
    {
        public string Id { get; set; }
        public string DogName { get; set; }
        public bool Male { get; set; }
        public bool Female { get; set; }
    }
}
