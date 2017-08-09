using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Ordbog.Models;
using Ordbog.Models.Synonyms;
using Ordbog.Models.Lemmas;

namespace Ordbog.DictionaryAPI
{
    public class Oxford
    {

        private static string BuildUrl(string word)
        {
            const string language = "en";
            var wordId = word.ToLower();  // word id is case sensitive and needs to be converted to lowercase
          
            return "https://od-api.oxforddictionaries.com:443/api/v1/entries/" + language + "/" + wordId;
        }

        private static Response<T> GetRequest<T>(string link)
        {

            const string appId = "02658d49";
            const string appKey = "0835c8bca54f8a2606f1d54c85442b14";
            var obj = new Response<T>();
            var client = new HttpClient();
            
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("app_id", appId);
            client.DefaultRequestHeaders.Add("app_key", appKey);

            try
            {

                var result = client.GetAsync(link).Result;
                
                obj.Error = result.StatusCode.ToString();
                obj.StatusCode = (int)result.StatusCode;
            
                var responseString = result.Content.ReadAsStringAsync().Result;
                var checkRes = JsonConvert.DeserializeObject<T>(responseString);
                Debug.WriteLine("checkres" + checkRes);
                if (checkRes != null)
                {
                    obj.Result = checkRes;
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine("Something went wrong in getrequest..: " + e.Message);
            }

            return obj;
        }

        public Response<SynAntoResponse> GetSynoynyms(string word)
        {    
            var url = BuildUrl(word) + "/synonyms;antonyms";
            var result = GetRequest<SynAntoResponse>(url);

            return result;
        }

        public Response<DefinitionResponse> GetDefinitions(string word)
        {
            var url = BuildUrl(word) + "/definitions";
            var result = GetRequest<DefinitionResponse>(url);

            return result;
        }

        public Response<LemmaResponse> GetLemmas(string word)
        {
            const string language = "en";
            const string limit = "50";
            const string prefix = "true";
            var q = word.ToLower();
            var url = "https://od-api.oxforddictionaries.com:443/api/v1/search/" + language + "?q=" +
            q + "&prefix=" + prefix + "&limit=" + limit;
            var result = GetRequest<LemmaResponse>(url);

            return result;
        }
    }

}
    

    

