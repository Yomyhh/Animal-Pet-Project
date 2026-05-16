using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetAdoption.BL.Interfaces;
using PetAdoption.DAL.Models;

namespace PetAdoption.PL.Controllers
{
    [Authorize]
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;
        private readonly UserManager<ApplicationUser> _userManager;

        public NotificationController(
            INotificationService notificationService,
            UserManager<ApplicationUser> userManager)
        {
            _notificationService = notificationService;
            _userManager = userManager;
        }

        public IActionResult MyNotifications()
        {
            var userId = _userManager.GetUserId(User);

            var notifications =
                _notificationService.GetUserNotifications(userId);

            return View(notifications);
        }
    }
}