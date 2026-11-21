using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Test_Taste_Console_Application.Constants;
using Test_Taste_Console_Application.Domain.DataTransferObjects;
using Test_Taste_Console_Application.Domain.DataTransferObjects.JsonObjects;
using Test_Taste_Console_Application.Domain.Objects;
using Test_Taste_Console_Application.Domain.Services.Interfaces;
using Test_Taste_Console_Application.Utilities;

namespace Test_Taste_Console_Application.Domain.Services
{
    /// <inheritdoc />
    public class PlanetService : IPlanetService
    {
        private readonly HttpClientService _httpClientService;

        public PlanetService(HttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<IEnumerable<Planet>> GetAllPlanets()
        {
            var allPlanetsWithTheirMoons = new Collection<Planet>();

            var response = await _httpClientService.Client.GetAsync(UriPath.GetAllPlanetsWithMoonsQueryParameters);

            //If the status code isn't 200-299, then the function returns an empty collection.
            if (!response.IsSuccessStatusCode)
            {
                Logger.Instance.Warn($"{LoggerMessage.GetRequestFailed}{response.StatusCode}");
                return allPlanetsWithTheirMoons;
            }

            var content = await response.Content.ReadAsStringAsync();

            //The JSON converter uses DTO's, that can be found in the DataTransferObjects folder, to deserialize the response content.
            var results = JsonConvert.DeserializeObject<JsonResult<PlanetDto>>(content);

            //The JSON converter can return a null object. 
            if (results == null) return allPlanetsWithTheirMoons;

            //If the planet doesn't have any moons, then it isn't added to the collection.
            foreach (var planet in results.Bodies)
            {
                if(planet.Moons != null)
                {
                    var newMoonsCollection = new Collection<MoonDto>();
                    foreach (var moon in planet.Moons)
                    {
                        var moonResponse = await _httpClientService.Client.GetAsync(UriPath.GetMoonByIdQueryParameters + moon.URLId);

                       
                        var moonContent = await moonResponse.Content.ReadAsStringAsync();

                        var moonDto = JsonConvert.DeserializeObject<MoonDto>(moonContent);

                        if (moonDto != null)
                        {
                            newMoonsCollection.Add(moonDto);
                        }
                    }
                    planet.Moons = newMoonsCollection;

                }
                allPlanetsWithTheirMoons.Add(new Planet(planet));
            }

            return allPlanetsWithTheirMoons;
        }

        private static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder(capacity: normalizedString.Length);

            for (int i = 0; i < normalizedString.Length; i++)
            {
                char c = normalizedString[i];
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder
                .ToString()
                .Normalize(NormalizationForm.FormC);
        }
    }
}
