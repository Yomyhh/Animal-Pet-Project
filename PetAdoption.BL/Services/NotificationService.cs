using PetAdoption.DAL.Interfaces;
using PetAdoption.DAL.Models;

namespace PetAdoption.BL.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepo _repo;

        public NotificationService(INotificationRepo repo)
        {
            _repo = repo;
        }

        public IEnumerable<Notification> GetUserNotifications(string userId)
        {
            return _repo.GetUserNotifications(userId);
        }
    }
}