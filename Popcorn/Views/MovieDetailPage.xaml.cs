using Microsoft.Extensions.DependencyInjection;
using Windows.UI.Xaml.Controls;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Popcorn.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MovieDetailPage : Page
    {
        public MovieDetailPage()
        {
            this.InitializeComponent();
            DataContext = App.Current.ServiceProvider.GetService<ViewModels.MovieDetailViewModel>();
        }
    }
}
