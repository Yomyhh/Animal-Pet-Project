using PetAdoption.DAL.Models;

namespace PetAdoption.DAL.Interfaces
{
    public interface INotificationRepo
    {
        IEnumerable<Notification> GetUserNotifications(string userId);
    }
}