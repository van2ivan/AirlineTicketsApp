using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.CompletedBookingAggregate;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(DbStoreContext context)
        {
            try
            {

                if (!context.Airports.Any())
                {
                    var airportsData = File.ReadAllText("../Infrastructure/Data/SeedData/airports.json");
                    var airports = JsonSerializer.Deserialize<List<Airport>>(airportsData);
                    foreach (var airport in airports)
                    {
                        context.Airports.Add(airport);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.Companies.Any())
                {
                    var companiesData = File.ReadAllText("../Infrastructure/Data/SeedData/companies.json");
                    var companies = JsonSerializer.Deserialize<List<Company>>(companiesData);
                    foreach (var company in companies)
                    {
                        context.Companies.Add(company);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.Planes.Any())
                {
                    var planesData = File.ReadAllText("../Infrastructure/Data/SeedData/planes.json");
                    var planes = JsonSerializer.Deserialize<List<Plane>>(planesData);
                    foreach (var plane in planes)
                    {
                        context.Planes.Add(plane);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.Flights.Any())
                {
                    var flightData = File.ReadAllText("../Infrastructure/Data/SeedData/flights.json");
                    var flights = JsonSerializer.Deserialize<List<Flight>>(flightData);
                    foreach (var flight in flights)
                    {
                        context.Flights.Add(flight);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.LuggageOptions.Any())
                {
                    var luggageData = File.ReadAllText("../Infrastructure/Data/SeedData/luggage.json");
                    var options = JsonSerializer.Deserialize<List<LuggageOption>>(luggageData);
                    foreach (var option in options)
                    {
                        context.LuggageOptions.Add(option);
                    }
                    await context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error seeding data" + ex);
            }
        }
    }
}