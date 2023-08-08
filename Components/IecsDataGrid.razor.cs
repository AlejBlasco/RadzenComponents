using Microsoft.AspNetCore.Components;
using RadzenComponents.Services;

namespace RadzenComponents.Components
{
    public partial class IecsDataGrid
    {
        private bool _isLoading = false;

        [Parameter]
        public IQueryable<Municipalality> Municipalalities { get; set; } = new List<Municipalality>().AsQueryable();

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await ShowLoading();
        }

        async Task ShowLoading()
        {
            _isLoading = true;
            await Task.Yield();
            _isLoading = false;
        }
    }
}
