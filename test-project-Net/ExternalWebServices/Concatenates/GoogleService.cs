using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using test_project_Net.Configurations;
using test_project_Net.Domain.GeoCodes;
using test_project_Net.ExternalWebServices.Interfaces;

namespace test_project_Net.ExternalWebServices.Concatenates
{
    public class GoogleService:IGoogleService
    {
        private readonly GoogleApiConfiguration _googleConfig;
        private readonly ILogger<string> _logger;
        public GoogleService(GoogleApiConfiguration googleConfig, ILogger<string> logger)
        {
            _googleConfig = googleConfig;
            _logger = logger;
        }
        public async Task<GoogleResponseModel> GetGeoCodeAddressAsync(string address)
        {

            var data = new GoogleResponseModel();
            try
            {
                using var client = new HttpClient();
                var apiAddress = _googleConfig.ApiAddress.Replace("<@Address@>", address).Replace("<@GeoCodeKey@>", _googleConfig.Key);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync(apiAddress);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<GoogleResponseModel>(result);

                }
                else
                {
                  _logger.LogError("Google service error !");
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }


            return data;
        }

        
    }
}
