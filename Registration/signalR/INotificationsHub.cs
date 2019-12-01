using System.Threading.Tasks;

namespace Registration.signalR
{
    public interface INotificationsHub
    {
        Task SendNotification(string message);
    }
}