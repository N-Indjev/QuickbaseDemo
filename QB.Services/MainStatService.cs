using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QB.Domain;
using QB.Services.Interfaces;
using QB.Services.Models;

namespace QB.Services
{
    public class MainStatService : IStatService
    {
        private readonly DbSet<City> cities;

        public MainStatService(DbContext dbContext)
        {
            this.cities = dbContext.Set<City>();
        }
        
        public List<CountryPopulation> GetCountryPopulation()
        {
            return QueryPopulation().ToList();
        }

        public Task<List<CountryPopulation>> GetCountryPopulationAsync()
        {
            return QueryPopulation().ToListAsync();
        }

        private IQueryable<CountryPopulation> QueryPopulation()
        {
            //EF has some limitations regarding GroupBy operations. For example it's not possible to select a column other than the grouping key, after grouping.
            //There are hacky solutions like Min(), Max(), but they introduce unnecessary operations when translated.
            //Currently I use a grouping on two columns, even though CountryName is unnecessary. However, that way EF can select the CountryName afterwards.
            //Grouping on CountryName only is possible as well, but not as reliable as grouping on CountryId, due to the fact that the name may collide with names for other IDs.
            //Such collision for CountryName must be considered a bug though, because it makes no sense to have two different country IDs with duplicate names.
            //Solution for that can be forcing unique constraint on CountryName.
            return cities
                .GroupBy(city => new {city.State!.CountryId, CountryName = city.State!.Country!.Name})
                .Select(group => new CountryPopulation
                {
                    CountryName = group.Key.CountryName,
                    Population = group.Sum(city => city.Population)
                });
            
            /*
             * That's the simplest variant of the query, however it must be executed as a raw SQL query, because EF cannot translate LINQ operations to form that result
             * 
                SELECT CountryName, SUM(Population) as Population FROM City as c
                JOIN State as s ON s.StateId=c.StateId
                JOIN Country as co ON s.CountryId=co.CountryId
                GROUP BY co.CountryId
             */
        }
    }
}