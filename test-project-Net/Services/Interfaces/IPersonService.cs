using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_project_Net.Domain.Models.Entities;
using test_project_Net.Services.ViewModels;

namespace test_project_Net.Services.Interfaces
{
    public interface IPersonService
    {
        Task<List<PersonView>> GetEstateForAllPersonAsync();
    }
}
