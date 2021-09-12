using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using test_project_Net.Services.Interfaces;
using test_project_Net.Services.ViewModels;

namespace test_project_Net.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IPersonService _personService;
        
        public IndexModel(ILogger<IndexModel> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }
        public static List<PersonView> People { get; set; }
        public async Task OnGetAsync()
        {
            
        var results = await _personService.GetStateForAllPersonAsync();
       People = results;
     
       
        }
        
    }
}
