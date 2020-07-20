using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReactiveUI;
using BasicCRUDTool3.Windows.ViewModels;
using System.Reactive.Disposables;

namespace BasicCRUDTool3.Blazor.Client.Pages
{
    public partial class AlbumsComponent
    {
        private bool showResults;
        public bool ShowResults
        {
            get => showResults;
            set
            {
                showResults = value;
                StateHasChanged();
            }
        }

        public AlbumsComponent()
        {
            ViewModel = new AlbumsViewModel();

            this.WhenActivated(disposableRegistration =>
            {
                this.OneWayBind(ViewModel, viewModel => viewModel.IsAvailable,
                    view => view.ShowResults)
                .DisposeWith(disposableRegistration);
            });
        }

    }
}
