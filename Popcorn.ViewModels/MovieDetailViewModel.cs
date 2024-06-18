using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Popcorn.Interfaces;
using Popcorn.Models.ReponseDto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Popcorn.ViewModels
{
    public class MovieDetailViewModel : ObservableObject
    {
        private readonly ILoggerManager loggerService;
        private readonly IMovie movieService;

        private Models.ReponseDto.Group movie;
        private List<Models.ReponseDto.Group> relatedMovies;

        public MovieDetailViewModel(
            ILoggerManager _loggerService,
            IMovie _movieService)
        {
            loggerService = _loggerService;
            movieService = _movieService;
            Movie = movieService.SelectedMovie;
            GetRelatedMovies();
        }

        public ICommand BackCommand => new RelayCommand(() =>
        {
            WeakReferenceMessenger.Default.Send(new Messenger.NavigationChangedMessage("dashboard"));
        });

        public ICommand PlayCommand => new RelayCommand(() =>
        {
            WeakReferenceMessenger.Default.Send(new Messenger.NavigationChangedMessage("player"));
        });

        private async void GetRelatedMovies()
        {
            var result = await movieService.GetListOfMoviesByPageAsync(4);
            if (result != null)
            {
                RelatedMovies = result.record.response.groups;
            }
        }

        public Models.ReponseDto.Group Movie { get => movie; set => SetProperty(ref movie, value); }
        public List<Group> RelatedMovies { get => relatedMovies; set => SetProperty(ref relatedMovies, value); }
    }
}
