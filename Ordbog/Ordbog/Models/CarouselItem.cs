using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Ordbog.Models
{
    public class CarouselItem
    {

        public string Category { get; set; }
        public string CategoryPrefix { get; set; }
        public ICollection<string> Synonyms;
        public ICollection<string> SubSynonyms;
        public string Antonym { get; set; }
 
        public string Example { get; set; }

        public CarouselItem()
        {
            Synonyms = new List<string>();
            SubSynonyms = new List<string>();
        }

        public IEnumerator<string> GetEnumerator()
        {
            return Synonyms.GetEnumerator();
        }

        public string GetPrefix(string category)
        {
            var prefix = "";

            switch (category)
            {
                case "Adjective":
                    prefix = "Adj";
                    break;
                case "Adverb":
                    prefix = "Adv";
                    break;
                case "Conjunction":
                    prefix = "Conj";
                    break;
                case "Combining_Form":
                    prefix = "Combining Form";
                    break;
                case "Contraction":
                    prefix = "Cont";
                    break;
                case "Determiner":
                    prefix = "Adj";
                    break;
                case "Idiomatic":
                    prefix = "Idio";
                    break;
                case "Interjection":
                    prefix = "Int";
                    break;
                case "Noun":
                    prefix = "Noun";
                    break;
                case "Numeral":
                    prefix = "Num";
                    break;
                case "Particle":
                    prefix = "Part";
                    break;
                case "Predeterminer":
                    prefix = "Pre";
                    break;
                case "Preposition":
                    prefix = "Prep";
                    break;
                case "Pronoun":
                    prefix = "Pronoun";
                    break;
                case "Residual":
                    prefix = "Res";
                    break;
                case "Suffix":
                    prefix = "Suf";
                    break;
                case "Verb":
                    prefix = "Verb";
                    break;
                default:
                    prefix = "Other";
                    break;
            }

            return prefix.ToLower();
        }
        
    }
}
