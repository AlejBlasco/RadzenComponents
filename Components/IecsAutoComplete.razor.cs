using RadzenComponents.Services;
using System.Linq;

namespace RadzenComponents.Components
{
    public partial class IecsAutoComplete
    {
        private readonly string _id = Guid.NewGuid().ToString();
        private string _searched = string.Empty;

        public string Value {get;set;} = string.Empty;
        
        public IEnumerable<Municipalality> Municipalalities {get;set;} = new List<Municipalality>();

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            Municipalalities = await new MunicipalalityService()
                .GetMunicipalalitiesAsync(Http);
        }

        void OnChange(dynamic args)
        {
            _searched = args;
        }
    }
}