using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace RadzenComponents.Services
{
    public class MunicipalalityService
    {
        public async Task<Municipalality[]> GetMunicipalalitiesAsync(HttpClient http)
        {
            var response = await http.GetFromJsonAsync<Municipalality[]>("sample-data/georef-spain-municipioy.json");
            
            return response != null
                ? response.OrderBy(m => m.Name).ToArray()
                : Array.Empty<Municipalality>();
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