using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Ordbog.Models
{
    public class WordViewModel
    {

        public string BaseWord { get; set; }
        public string Category { get; set; }
        public List<CarouselItem> Blocks;
        public ICollection<string> Lemmas;
        public string ErrorMsg { get; set; }
        public int CurrentIndex { get; set; }



        public WordViewModel()
        {
            Blocks = new List<CarouselItem>();
            Lemmas = new List<string>();
            CurrentIndex = 0;
        }
    }
}
