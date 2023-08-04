using RadzenComponents.Services;

namespace RadzenComponents.Components
{
    public partial class IecsAutoComplete
    {
        private readonly string _id = Guid.NewGuid().ToString();
        private string _searched = string.Empty;

    public string Value {get;set;} = string.Empty;
    public IEnumerable<City> Cities {get; set;} = new List<City>()
        {
            new City{ Id = Guid.NewGuid().ToString(), Name = "Agurain/Salvatierra", Code = "3"},
            new City{ Id = Guid.NewGuid().ToString(), Name = "Alegría-Dulantzi", Code = "4"},
            new City{ Id = Guid.NewGuid().ToString(), Name = "Amurrio", Code = "9"},
            new City{ Id = Guid.NewGuid().ToString(), Name = "Añana", Code = "3"},
            new City{ Id = Guid.NewGuid().ToString(), Name = "Zaragoza", Code = "3"},
            new City{ Id = Guid.NewGuid().ToString(), Name = "Zuera", Code = "9"},
            new City{ Id = Guid.NewGuid().ToString(), Name = "Ceuta", Code = "3"},
            new City{ Id = Guid.NewGuid().ToString(), Name = "Melilla", Code = "8"},
        };

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        var municipalities = await new MunicipalalityService()
            .GetMunicipalalitiesAsync(Http);

        IEnumerable<Municipalality> aux = municipalities;
        
        var stop = "hammer time";
    }

    void OnChange(dynamic args)
    {
        _searched = args;
    }


    public class City
    {
        public string Id {get;set;} = string.Empty;
        public string Name {get;set;} = string.Empty;
        public string Code {get;set;} = string.Empty;
    }
    }
}