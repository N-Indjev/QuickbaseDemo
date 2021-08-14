using System.Collections.Generic;
using System.Threading.Tasks;
using QB.Services.Models;

namespace QB.Services.Interfaces
{
    /// <summary>
    /// Aggregates statistics data for countries from a single data provider at best.
    /// </summary>
    public interface IStatService
    {
        //Left for completeness, but in production I would remove the sync variant due to operations like these being very
        //time consuming and blocking the main thread is not a good idea.
        List<CountryPopulation> GetCountryPopulation();
        Task<List<CountryPopulation>> GetCountryPopulationAsync();
    }
}
