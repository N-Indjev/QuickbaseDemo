using QB.Services.Models;
using QB.WebApi.ViewModels;

namespace QB.WebApi.Mapping
{
    public static class MappingHelper
    {
        //The view model and the service model are exactly the same in our case.
        //However, separating DTOs returned from business layer and the one used for presentation are best kept separate.
        //I usually use mapping libraries like Automapper, but for simplicity I use manual mapping here.
        public static PopulationViewModel ToViewModel(CountryPopulation data)
        {
            (string countryName, int population) = data;

            return new PopulationViewModel
            {
                CountryName = countryName,
                Population = population
            };
        }
    }
}