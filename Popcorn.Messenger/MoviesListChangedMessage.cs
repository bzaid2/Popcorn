using CommunityToolkit.Mvvm.Messaging.Messages;
using Popcorn.Models.ReponseDto;

namespace Popcorn.Messenger
{
    public class MoviesListChangedMessage : ValueChangedMessage<Root>
    {
        public MoviesListChangedMessage(Root value) : base(value)
        {
        }
    }
}
