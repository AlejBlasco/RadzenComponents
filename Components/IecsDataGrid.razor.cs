using RadzenComponents.Services;
using System.Linq;

namespace RadzenComponents.Components
{
    public partial class IecsDataGrid
    {
        public IQueryable<Municipalality> Municipalalities { get; set; } 

        private bool _isLoading = false;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            await ShowLoading();

            Municipalalities = (await new MunicipalalityService()
                .GetMunicipalalitiesAsync(Http))
                .AsQueryable();

        }

        async Task ShowLoading()
        {
            _isLoading = true;
            await Task.Yield();
            _isLoading = false;
        }
    }
}
