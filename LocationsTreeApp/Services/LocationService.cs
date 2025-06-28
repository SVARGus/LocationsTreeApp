using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using System.Text.Json;
using LocationsTreeApp.Models;

namespace LocationsTreeApp.Services
{
    public class LocationService : ILocationService
    {
        private const string Url = "http://p.inventsoft.ru/Locations/GetLocations";
        private const string ApiKey = "4FF19AD779254EDBAA26B47002144DF6";

        readonly HttpClient _httpClient;

        public LocationService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(ApiKey);
        }

        public async Task<ObservableCollection<LocationNode>> GetTreeAsync()
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string>("clientid","5")
            });
            var resp = await _httpClient.PostAsync(Url, content);
            resp.EnsureSuccessStatusCode();

            var json = await resp.Content.ReadAsStringAsync();

            var dtos = JsonSerializer.Deserialize<List<LocationDto>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true});

            var dict = dtos.ToDictionary( d => d.Id, d => new LocationNode { Id = d.Id, Name = d.Name });

            var roots = new ObservableCollection<LocationNode>();
            foreach (var dto in dtos)
            {
                var node = dict[dto.Id];
                if (dto.Parent_ID == null || dto.Parent_ID == 0)
                {
                    roots.Add(node);
                }
                else if (dict.TryGetValue(dto.Parent_ID.Value, out var parent))
                {
                    parent.Children.Add(node);
                }
            }

            return roots;
        }
    }
}
