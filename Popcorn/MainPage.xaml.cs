using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using Popcorn.Views;
using System;
using Windows.Media.Playback;
using Windows.UI.Xaml.Controls;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace Popcorn
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            DataContext = App.Current.ServiceProvider.GetService<ViewModels.MainViewModel>();
            frame.Navigate(typeof(DashboardPage));
            WeakReferenceMessenger.Default.Register<Messenger.NavigationChangedMessage>(this, (r, m) =>
            {
                switch (m.Value)
                {
                    case "dashboard":
                        frame.Navigate(typeof(DashboardPage));
                        break;
                    case "detail":
                        frame.Navigate(typeof(MovieDetailPage));
                        break;
                    case "player":
                        frame.Navigate(typeof(PlayerPage));
                        break;
                }
            });
        }
    }
}
