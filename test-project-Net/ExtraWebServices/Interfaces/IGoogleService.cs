using System.Threading.Tasks;
using test_project_Net.Domain.Models.GeoCodes;

namespace test_project_Net.ExtraWebServices.Interfaces
{
    public interface IGoogleService
    {
        Task<Root> GetGeoCodeAddressAsync(string address);
    }
}
