using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using test_project_Net.Domain.Models.GeoCodes;
using test_project_Net.ExtraWebServices.Interfaces;

namespace test_project_Net.ExtraWebServices.Concatenates
{
    public class GoogleService:IGoogleService
    {
        public async Task<Root> GetGeoCodeAddressAsync(string address)
        {
            var data = new Root();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://maps.googleapis.com");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync($"/maps/api/geocode/json?address={address}&key=AIzaSyBIHWg56dGw3SWOMH-8k9_NPa_wyFVoPuo");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    data= JsonConvert.DeserializeObject<Root>(result);

                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }

            return data;
        }
    }
}
