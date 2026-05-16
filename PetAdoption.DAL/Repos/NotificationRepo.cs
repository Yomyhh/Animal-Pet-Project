using Microsoft.EntityFrameworkCore;
using PetAdoption.DAL.Interfaces;
using PetAdoption.DAL.Models;

namespace PetAdoption.DAL.Repositories
{
    public class NotificationRepo : INotificationRepo
    {
        private readonly AppDbContext _context;

        public NotificationRepo(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Notification> GetUserNotifications(string userId)
        {
            return _context.Notifications
                .Where(n => n.UserId == userId)
                .OrderByDescending(n => n.Date)
                .ToList();
        }
    }
}