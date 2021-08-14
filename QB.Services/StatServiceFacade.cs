using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using QB.Services.Interfaces;
using QB.Services.Models;

namespace QB.Services
{
    public class StatServiceFacade : IStatServiceFacade
    {
        private readonly ILogger logger;
        private readonly IStatService[] statServices;

        public StatServiceFacade(ILogger<StatServiceFacade> logger, IEnumerable<IStatService> statServices)
        {
            this.logger = logger;
            this.statServices = statServices.OrderBy(GetServicePriority).ToArray();
        }

        public IEnumerable<CountryPopulation> GetCountryPopulation()
        {
            IEnumerable<List<CountryPopulation>> results = statServices.Select(s => s.GetCountryPopulation());
            return Combine(results);
        }

        public async Task<IEnumerable<CountryPopulation>> GetCountryPopulationAsync()
        {
            List<CountryPopulation>[] results = await Task.WhenAll(statServices.Select(s => s.GetCountryPopulationAsync()));
            return Combine(results);
        }

        /// <summary>
        /// Accumulates country population data from multiple sources, choosing the most accurate one (currently based on priority)
        /// </summary>
        /// <param name="results">Country population data usually from different data sources.</param>
        /// <returns>Accumulated country population data.</returns>
        private IEnumerable<CountryPopulation> Combine(IEnumerable<List<CountryPopulation>> results)
        {
            HashSet<CountryPopulation> populations = new();

            foreach(List<CountryPopulation> result in results)
            {
                foreach(var countryPopulation in result)
                {
                    if(populations.Add(countryPopulation))
                        continue;

                    logger.LogWarning($"Population data for '{countryPopulation}' already present in result set");
                }
            }

            return populations;
        }

        /// <summary>
        /// Prioritizes the statistics service data. Data accumulated is based on that priority later on.
        /// Lower priority data is discarded if already exists in the result set.
        /// </summary>
        /// <param name="service">The service to be used to fetch data</param>
        /// <returns>The priority</returns>
        private static int GetServicePriority(IStatService service)
        {
            return service switch
            {
                MainStatService => 0,
                AlternativeStatService => 1,
                _ => 99
            };
        }
    }
}