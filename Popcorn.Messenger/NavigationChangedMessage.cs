using CommunityToolkit.Mvvm.Messaging.Messages;
using Popcorn.Models.ReponseDto;

namespace Popcorn.Messenger
{
    public class NavigationChangedMessage : ValueChangedMessage<string>
    {
        public NavigationChangedMessage(string value) : base(value)
        {
        }
    }
}
