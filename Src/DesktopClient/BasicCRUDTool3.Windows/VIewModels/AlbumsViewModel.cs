using BasicCRUDTool3.Business;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ReactiveUI;
using BasicCRUDTool3.Windows.Services;
using Splat;
using System.Threading.Tasks;
using System.Threading;
using System.Reactive.Linq;

namespace BasicCRUDTool3.Windows.ViewModels
{
    public class AlbumsViewModel : ReactiveObject
    {
        #region Private Members
        private string searchTerm;
        private readonly IAlbumsService albumsService;
        private readonly ObservableAsPropertyHelper<IEnumerable<AlbumViewModel>> searchResults;
        private readonly ObservableAsPropertyHelper<bool> isAvailable;
        #endregion

        #region Public Properties
        public bool IsAvailable => isAvailable.Value;
        public IEnumerable<AlbumViewModel> SearchResults => searchResults.Value;
        public string SearchTerm
        {
            get
            {
                return searchTerm;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref searchTerm, value);
            } 
        }
        #endregion

        public AlbumsViewModel(IAlbumsService albumsService = null)
        {
            if (albumsService is null) this.albumsService = Locator.Current.GetService<IAlbumsService>();

            searchResults = this
                .WhenAnyValue(x => x.SearchTerm)
                .Throttle(TimeSpan.FromMilliseconds(800))
                .Select(num => num?.Trim())
                .DistinctUntilChanged()
                .Where(num => !string.IsNullOrWhiteSpace(num))
                .Where(num => int.TryParse(num, out _))
                .SelectMany(GetNumberOfAlbums)
                .ObserveOn(RxApp.MainThreadScheduler)
                .ToProperty(this, x => x.SearchResults);

            searchResults.ThrownExceptions.Subscribe(error => { /* Handle errors here */ });

            isAvailable = this
                .WhenAnyValue(x => x.SearchResults)
                .Select(searchResults => searchResults != null)
                .ToProperty(this, x => x.IsAvailable);
        }

        private async Task<IEnumerable<AlbumViewModel>> GetNumberOfAlbums( string num, CancellationToken token)
        {
            int numInt = int.Parse(num);
            var result = await albumsService.GetNumberOfAlbums(numInt);
            return result.Select(x => new AlbumViewModel(x));
        }
    }
}
