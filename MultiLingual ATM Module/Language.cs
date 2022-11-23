using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultizLingual_ATM_Module
{
    internal class Language
    {
        //Dictionary<int, string> LangText = new Dictionary<int, string>();

        //public Language()
        //{
        //    LangText.Add((int)SelectedLanguage.English, "Enter Your Card Number");
        //    LangText.Add((int)SelectedLanguage.Igbo, "Tinye Password gi");
        //    LangText.Add((int)SelectedLanguage.Pidgin, "Oboy, sakpa me ya password");
        //}

        public Language()
        {

        }

        public enum SelectedLanguage
        {
            English = 1,
            Pidgin,
            Igbo

        }


       
        public static async Task Translate(string targetlanguageCode, string message)
        {
                         
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("https://google-translate1.p.rapidapi.com/language/translate/v2"),
                    Headers =  {
                                 { "X-RapidAPI-Key", "3ca59f2b37msh06f1da4d82c4435p138bc8jsnc99ebdec4518" },
                                 { "X-RapidAPI-Host", "google-translate1.p.rapidapi.com" },
                                },
                                    Content = new FormUrlEncodedContent(new Dictionary<string, string>
                                        {
                                          { "q", message },
                                          { "target", targetlanguageCode },
                                          { "source", "en" },
                                             }),
                                            };


                //   var response = await client.SendAsync(request);
                var response = client.Send(request);

            
           
            response.EnsureSuccessStatusCode();

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Language Translation Api Could not be reached. Check your interenet connection");
            }

            var body = await response.Content.ReadAsStringAsync();
           
            if (body.Contains("translatedText"))
            {
                
                Console.OutputEncoding = Encoding.UTF8;
           
               Console.WriteLine(SerializeResponse(body.ToString()));
            }
            else
            {
                Console.WriteLine("Language Translation Api Could not be reached. Check your interenet connection");
            }
               
 
         }



        public static string SerializeResponse(string response)
        {
            // Sample Response
            ////{ "data":{ "translations":[{ "translatedText":"Mmadụ Bịa na Zenith Bank Atm Machine"}]} }
            //System.Threading.Tasks.Task`1[System.Threading.Tasks.VoidTaskResult]

            response = response.Remove(0, 44);
            response = response.Remove(response.Length - 5, 5);



            return response;
        }


        
    }
}
