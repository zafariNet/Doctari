using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using test_project_Net.Domain;
using test_project_Net.Services.ViewModels;

namespace test_project_Net.Services
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<State, StateView>();
            CreateMap<Person, PersonView>();
        }
    }
}
