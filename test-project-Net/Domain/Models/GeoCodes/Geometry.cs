using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_project_Net.Domain.Models.GeoCodes
{
    public class Geometry
    {
        public Location Location { get; set; }
        public string Location_Type { get; set; }
        public Viewport ViewPort { get; set; }
    }
}
