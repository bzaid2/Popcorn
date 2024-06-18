using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Windows.Input;
using Windows.Media;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI.Xaml.Controls;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Popcorn.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class PlayerPage : Page
    {
        private MediaPlayer mediaPlayer;
        MediaTimelineController _mediaTimelineController;

        public PlayerPage()
        {
            this.InitializeComponent();
            mediaPlayer = new MediaPlayer();
            mediaPlayer.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/ForBiggerEscapes.mp4"));
            _mediaPlayerElement.SetMediaPlayer(mediaPlayer);
            _mediaTimelineController = new MediaTimelineController();
            mediaPlayer.TimelineController = _mediaTimelineController;
            _mediaTimelineController.Resume();
        }

        private void btnRepeat_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            _mediaTimelineController.Position = TimeSpan.Zero;
            _mediaTimelineController.Resume();
        }

        private void btnForward_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var session = mediaPlayer.PlaybackSession;
            _mediaTimelineController.Position = _mediaTimelineController.Position + TimeSpan.FromSeconds(10);
        }

        private void btnBack_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var session = mediaPlayer.PlaybackSession;
            if (_mediaTimelineController.Position > TimeSpan.FromSeconds(10))
                _mediaTimelineController.Position = _mediaTimelineController.Position - TimeSpan.FromSeconds(10);
        }

        private void btnPlay_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (_mediaTimelineController.State == MediaTimelineControllerState.Running)
            {
                _mediaTimelineController.Pause();
                play.Symbol = Symbol.Pause; // TODO: Arreglar el cambio de imagen
            }
            else
            {
                _mediaTimelineController.Resume();
                play.Symbol = Symbol.Play;
            }
        }

        private void btnReturn_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            WeakReferenceMessenger.Default.Send(new Messenger.NavigationChangedMessage("detail"));
        }
    }
}
