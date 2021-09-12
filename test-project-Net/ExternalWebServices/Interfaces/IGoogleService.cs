using System.Threading.Tasks;
using test_project_Net.Domain.GeoCodes;

namespace test_project_Net.ExternalWebServices.Interfaces
{
    public interface IGoogleService
    {
        Task<GoogleResponseModel> GetGeoCodeAddressAsync(string address);
    }
}
