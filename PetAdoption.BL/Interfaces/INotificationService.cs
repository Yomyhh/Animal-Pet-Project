using PetAdoption.DAL.Models;

public interface INotificationService
{
    IEnumerable<Notification> GetUserNotifications(string userId);
}