using Microsoft.AspNetCore.Components;
using RadzenComponents.Services;

namespace RadzenComponents.Components
{
    public partial class IecsAutoComplete
    {
        private readonly string _id = Guid.NewGuid().ToString();
        private string _searched = string.Empty;

        public string Value {get;set;} = string.Empty;
        
        [Parameter]
        public IEnumerable<Municipalality> Municipalalities {get;set;} = new List<Municipalality>();

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        void OnChange(dynamic args)
        {
            _searched = args;
        }
    }
}