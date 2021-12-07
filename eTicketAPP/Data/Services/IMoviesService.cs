using eTicketAPP.Data.Base;
using eTicketAPP.Data.ViewModels;
using eTicketAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicketAPP.Data.Services
{
    public interface IMoviesService:IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropDownVM> GetNewMovieDropDownValues();
        Task AddNewMovie(NewMovieVM data);
        Task UpdateNewMovie(NewMovieVM data);

    }
}
