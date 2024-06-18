using CommunityToolkit.Mvvm.Messaging.Messages;
using Popcorn.Models.ReponseDto;

namespace Popcorn.Messenger
{
    public class SelectedMovieChangedMessage : ValueChangedMessage<Models.ReponseDto.Group>
    {
        public SelectedMovieChangedMessage(Models.ReponseDto.Group value) : base(value)
        {
        }
    }
}
