using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Organizer
{
    class Wheather
    {

        public void whetherRequest(string city)
        {
           

            string apiId = "c43ea5594fd4d8abf8690cdf5b4cf537";
            string url = ("http://api.openweathermap.org/data/2.5/weather?q="+city + "&units=metric&appid="+ apiId);

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse httpWebRsponse = (HttpWebResponse)httpWebRequest.GetResponse();
            string response;
            using (StreamReader streamReader = new StreamReader(httpWebRsponse.GetResponseStream()))
            {

                response = streamReader.ReadToEnd();
            }

            WhetherResponse whetherResponse = JsonConvert.DeserializeObject<WhetherResponse>(response);

            Console.WriteLine("Temperature in {0}: {1} C", whetherResponse.Name, whetherResponse.Main.Temp);
        }

        public Dictionary<int, string> ChooseCities()
        {
            Dictionary<int, string> cities = new Dictionary<int, string>();
            cities.Add(1, "Kharkiv");
            cities.Add(2, "Kiev");    
            cities.Add(3, "Lviv");

            return cities;


            
        }

        public void GetWhether()
        {
            Console.Clear();
            Console.WriteLine("Please choose the city:\n");
            
            foreach (KeyValuePair<int, string> kvp in ChooseCities())
                Console.WriteLine("[" + kvp.Key + "]" + kvp.Value);

            string error = "Sorry, we don`t have whether for this city\n"; ;
            string city;
            Dictionary<int, string> cities = ChooseCities();
            do
            {
                int com = Helper.ReadCommandsInt();
                city = com == 1 ? cities[1] : com == 2 ? cities[2] : com == 3 ? cities[3] : error;
            } while (city.Equals(error));
            whetherRequest(city);

        }

    }
}

