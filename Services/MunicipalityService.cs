using System.Net.Http.Json;
using System.Text.Json.Serialization;


namespace RadzenComponents.Services
{
    public class MunicipalalityService
    {
        private readonly HttpClient _http;
        private readonly string _inputPath = "sample-data/georef-spain-municipio-aragon.json";

        public MunicipalalityService(HttpClient http)
        {
            _http = http 
                ?? throw new ArgumentNullException(nameof(http));
        }

        public async Task<IQueryable<Municipalality>> GetMunicipalalitiesQueryAsync()
        {
            var response = await _http.GetFromJsonAsync<Municipalality[]>(_inputPath);
            return response != null
                ? response.OrderBy(m => m.Name).AsQueryable() 
                : new List<Municipalality>().AsQueryable();
        }
    }

    public class Municipalality
    {
        public int Year {get;set;}
         
        [JsonPropertyName("mun_code")]
        public string Code {get; set;} = string.Empty;
        
        [JsonPropertyName("mun_name")]
        public string Name {get; set;} = string.Empty;
        
        [JsonPropertyName("mun_area_code")]
        public string AreaCode {get; set;} = string.Empty;
        
        [JsonPropertyName("mun_type")]
        public string Type {get; set;} = string.Empty;
    }
}