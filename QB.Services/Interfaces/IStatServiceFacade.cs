using System.Collections.Generic;
using System.Threading.Tasks;
using QB.Services.Models;

namespace QB.Services.Interfaces
{
    /// <summary>
    /// Aggregates statistics data for countries from multiple data providers
    /// </summary>
    public interface IStatServiceFacade
    {
        //Left for completeness, but in production I would remove the sync variant due to operations like these being very
        //time consuming and blocking the main thread is not a good idea.
        IEnumerable<CountryPopulation> GetCountryPopulation();
        Task<IEnumerable<CountryPopulation>> GetCountryPopulationAsync();
    }
}