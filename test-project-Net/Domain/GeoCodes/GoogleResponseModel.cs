using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using test_project_Net.Domain.Models.GeoCodes;

namespace test_project_Net.Domain.GeoCodes
{
    public class GoogleResponseModel
    {
        public List<Result> Results { get; set; }
        public string Status { get; set; }
        
    }

    public enum PersonDataStatus
    {
        [Display(Name = "From Google")]
        StateComesFromGoogle,
        [Display(Name = "From File")]
        SateComesFromFile,
    }
}
