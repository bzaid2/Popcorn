using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Popcorn.Interfaces;
using Popcorn.Models.ReponseDto;
using System;
using System.Collections.Generic;

namespace Popcorn.ViewModels
{
    public class DashboardViewModel : ObservableObject
    {
        private readonly ILoggerManager loggerService;
        private readonly IMovie movieService;

        private List<Models.ReponseDto.Group> bannerMovies;
        private List<Models.ReponseDto.Group> recommendedMovies;
        private List<Models.ReponseDto.Group> premiumMovies;

        private Models.ReponseDto.Group selectedGroup;
        
        public DashboardViewModel(
            ILoggerManager _loggerService,
            IMovie _movieService)
        {
            loggerService = _loggerService;
            movieService = _movieService;
            // TODO: Hacer invocación por task
            GetBannerMovies();
            GetRecommendedMovies();
            GetPremiumMovies();
        }

        public async void GetBannerMovies()
        {
            try
            {
                var result = await movieService.GetListOfMoviesByPageAsync(1);
                if (result != null)
                {
                    BannerMovies = result.record.response.groups;
                }
            }
            catch (Exception ex)
            {
                loggerService.Error("Error al consultar la lista de películas");
            }
        }

        public async void GetRecommendedMovies()
        {
            try
            {
                var result = await movieService.GetListOfMoviesByPageAsync(2);
                if (result != null)
                {
                    RecommendedMovies = result.record.response.groups;
                }
            }
            catch (Exception ex)
            {
                loggerService.Error("Error al consultar la lista de películas");
            }
        }

        public async void GetPremiumMovies()
        {
            try
            {
                var result = await movieService.GetListOfMoviesByPageAsync(3);
                if (result != null)
                {
                    PremiumMovies = result.record.response.groups;
                }
            }
            catch (Exception ex)
            {
                loggerService.Error("Error al consultar la lista de películas");
            }
        }

        

        public List<Group> BannerMovies { get => bannerMovies; set => SetProperty(ref bannerMovies, value); }
        public List<Group> RecommendedMovies { get => recommendedMovies; set => SetProperty(ref recommendedMovies, value); }
        public List<Group> PremiumMovies { get => premiumMovies; set => SetProperty(ref premiumMovies, value); }
        public Group SelectedGroup 
        { 
            get => selectedGroup;
            set
            {
                selectedGroup = value;
                movieService.SelectedMovie = value;
                WeakReferenceMessenger.Default.Send(new Messenger.NavigationChangedMessage("detail"));
            }
        }
    }
}
