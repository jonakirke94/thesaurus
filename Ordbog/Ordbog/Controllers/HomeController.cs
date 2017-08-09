using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Ordbog.DictionaryAPI;
using Ordbog.Models;
using Ordbog.Models.Lemmas;
using Ordbog.Models.Synonyms;

namespace Ordbog.Controllers
{
    public class HomeController : Controller
    {
        private static WordViewModel _viewModel;

        public IActionResult Index(string query, int id)
        {
            if (_viewModel == null)
            {
                _viewModel = new WordViewModel { BaseWord = query};
            }

            if (!string.IsNullOrEmpty(_viewModel?.BaseWord) && _viewModel.BaseWord.Equals(query))
            {
                id = id < 0 || id >= _viewModel.Blocks.Count ? 0 : id;
                _viewModel.CurrentIndex = id;
            }
            else
            {
                if (string.IsNullOrEmpty(query))
                {
                    if(!string.IsNullOrEmpty(_viewModel.ErrorMsg)) {
                        _viewModel = new WordViewModel
                        {
                            ErrorMsg = "You tried to search on nothing.."
                        };
                    }
                    return View(_viewModel);
                }

                if(!IsValid(query))
                {
                    _viewModel = new WordViewModel { 
                        ErrorMsg = "You entered an invalid character - Only alphabets and ',-` are valid"
                    };
                    return View(_viewModel);
                }

                _viewModel = new WordViewModel { BaseWord = query };
                var client = new Oxford();
                var resultSyn = client.GetSynoynyms(query);

                if (resultSyn.StatusCode != 200)
                {
                    FindLemmas(client.GetLemmas(query));                                  
                }
                else
                {
                    CreateCarousel(resultSyn);        
                }
            }




            return View(_viewModel);
        }

        public IActionResult Info()
        {
            {
                return View();
            }
        }


        private static void FindLemmas(Response<LemmaResponse> res)
        {
            {
                if (!res.Result.Results.Any())
                    _viewModel.ErrorMsg = "Try another searchword";
                else
                    foreach (var a in res.Result.Results)
                        _viewModel.Lemmas.Add(a.Word);
            }
        }

        private static bool IsValid(string text)
        {
            if (string.IsNullOrEmpty(text)) return false;
            
            const string pattern =  @"^[a-zA-Z',-`]+$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);

            Debug.WriteLine("---------------------------------@@@@@@ " + regex.Match(text).Success);
            return regex.Match(text).Success;
        
            
        }

        private static void CreateCarousel(Response<SynAntoResponse> res)
        {
            //iterate through entries and put each element into a CarouselItem object. 
            foreach (var a in res.Result.Results.FirstOrDefault().LexicalEntries)
            foreach (var b in a.Entries)
            foreach (var c in b.Senses)
            {
                var cItem = new CarouselItem();

                if (c.Antonyms != null && c.Antonyms.Any())
                    cItem.Antonym = c.Antonyms.FirstOrDefault().Text;
                else
                    cItem.Antonym = "No antonym found";
                cItem.Example = c.Examples.FirstOrDefault().Text;
                cItem.Category = cItem.GetPrefix(a.LexicalCategory);

                foreach (var d in c.Synonyms)
                    cItem.Synonyms.Add(d.Text);
                if (c.Subsenses != null)
                    foreach (var e in c.Subsenses)

                    foreach (var f in e.Synonyms)
                        cItem.SubSynonyms.Add(f.Text);
                _viewModel.Blocks.Add(cItem);
            }
        }
    }
}