using BasicCRUDTool3.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BasicCRUDTool3.Business
{
    public class Business
    {
        #region Private members
        private readonly ICRUDTestDBContextProvider cRUDTestDBContextProvider;
        #endregion

        #region Constructors
        public Business(ICRUDTestDBContextProvider cRUDTestDBContextProvider)
        {
            this.cRUDTestDBContextProvider = cRUDTestDBContextProvider;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Return all AlbumBEs
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AlbumBE> GetAlbumBEs()
        {
            using var context = cRUDTestDBContextProvider.GetContext();
            foreach (var id in context.Album.Select(p => p.AlbumId))
            {
                AlbumBE albumBE = new AlbumBE(cRUDTestDBContextProvider);

                albumBE.Load(id);

                yield return albumBE;
            }
        }

        /// <summary>
        /// Return all ArtistBEs
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ArtistBE> GetArtistBEs()
        {
            using var context = cRUDTestDBContextProvider.GetContext();
            foreach (var id in context.Artist.Select(p => p.ArtistId))
            {
                ArtistBE artistBE = new ArtistBE(cRUDTestDBContextProvider);

                artistBE.Load(id);

                yield return artistBE;
            }
        }

        /// <summary>
        /// Return all CustomerBEs
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CustomerBE> GetCustomerBEs()
        {
            using var context = cRUDTestDBContextProvider.GetContext();
            foreach (var id in context.Customer.Select(p => p.CustomerId))
            {
                CustomerBE customerBE = new CustomerBE(cRUDTestDBContextProvider);

                customerBE.Load(id);

                yield return customerBE;
            }
        }

        /// <summary>
        /// Return all EmployeeBEs
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EmployeeBE> GetEmployeeBEs()
        {
            using var context = cRUDTestDBContextProvider.GetContext();
            foreach (var id in context.Employee.Select(p => p.EmployeeId))
            {
                EmployeeBE employeeBE = new EmployeeBE(cRUDTestDBContextProvider);

                employeeBE.Load(id);

                yield return employeeBE;
            }
        }

        /// <summary>
        /// Return all GenreBEs
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GenreBE> GetGenreBEs()
        {
            using var context = cRUDTestDBContextProvider.GetContext();
            foreach (var id in context.Genre.Select(p => p.GenreId))
            {
                GenreBE genreBE = new GenreBE(cRUDTestDBContextProvider);

                genreBE.Load(id);

                yield return genreBE;
            }
        }

        /// <summary>
        /// Return all InvoiceBEs
        /// </summary>
        /// <returns></returns>
        public IEnumerable<InvoiceBE> GetInvoiceBEs()
        {
            using var context = cRUDTestDBContextProvider.GetContext();
            foreach (var id in context.Invoice.Select(p => p.InvoiceId))
            {
                InvoiceBE invoiceBE = new InvoiceBE(cRUDTestDBContextProvider);

                invoiceBE.Load(id);

                yield return invoiceBE;
            }
        }

        /// <summary>
        /// Return all InvoiceLineBEs
        /// </summary>
        /// <returns></returns>
        public IEnumerable<InvoiceLineBE> GetInvoiceLineBEs()
        {
            using var context = cRUDTestDBContextProvider.GetContext();
            foreach (var id in context.InvoiceLine.Select(p => p.InvoiceLineId))
            {
                InvoiceLineBE invoiceLineBE = new InvoiceLineBE(cRUDTestDBContextProvider);

                invoiceLineBE.Load(id);

                yield return invoiceLineBE;
            }
        }

        /// <summary>
        /// Return all MediaTypeBEs
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MediaTypeBE> GetMediaTypeBEs()
        {
            using var context = cRUDTestDBContextProvider.GetContext();
            foreach (var id in context.MediaType.Select(p => p.MediaTypeId))
            {
                MediaTypeBE mediaTypeBE = new MediaTypeBE(cRUDTestDBContextProvider);

                mediaTypeBE.Load(id);

                yield return mediaTypeBE;
            }
        }

        /// <summary>
        /// Return all PlaylistBEs
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PlaylistBE> GetPlaylistBEs()
        {
            using var context = cRUDTestDBContextProvider.GetContext();
            foreach (var id in context.Playlist.Select(p => p.PlaylistId))
            {
                PlaylistBE playlistBE = new PlaylistBE(cRUDTestDBContextProvider);

                playlistBE.Load(id);

                yield return playlistBE;
            }
        }

        /// <summary>
        /// Return all PlaylistTrackBEs
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PlaylistTrackBE> GetPlaylistTrackBEs()
        {
            using var context = cRUDTestDBContextProvider.GetContext();
            foreach (var id in context.PlaylistTrack
                .Select(p => new { p.PlaylistId, p.TrackId })
                .ToList()
                .Select(p => ((int)p.PlaylistId, (int)p.TrackId)))
            {
                PlaylistTrackBE playlistTrackBE = new PlaylistTrackBE(cRUDTestDBContextProvider);

                playlistTrackBE.Load(id, id.Item1, id.Item2);

                yield return playlistTrackBE;
            }
        }

        /// <summary>
        /// Return all TrackBEs
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TrackBE> GetTrackBEs()
        {
            using var context = cRUDTestDBContextProvider.GetContext();
            foreach (var id in context.Track.Select(p => p.TrackId))
            {
                TrackBE trackBE = new TrackBE(cRUDTestDBContextProvider);

                trackBE.Load(id);

                yield return trackBE;
            }
        }
        #endregion
    }
}
