using BasicCRUDTool3.Business;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ReactiveUI;

namespace BasicCRUDTool3.Windows.ViewModels
{
    public class AlbumsViewModel : ReactiveObject
    {
        private string searchTerm;

        private readonly ObservableAsPropertyHelper<IEnumerable<AlbumViewModel>> searchResults;

        private readonly ObservableAsPropertyHelper<bool> isAvailable;

        #region Public Properties
        public bool IsAvailable => isAvailable.Value;
        public IEnumerable<AlbumViewModel> SearchResults => searchResults.Value;
        #endregion

        public AlbumsViewModel()
        {
            //Albums = new Business.Business().GetAlbumBEs();
        }
    }
}
