using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetAdoption.BL.Interfaces;
using PetAdoption.DAL.Models;

public class AdoptionController : Controller
{
    private readonly IAdoptionService _service;
    private readonly UserManager<ApplicationUser> _userManager;

    public AdoptionController(
        IAdoptionService service,
        UserManager<ApplicationUser> userManager)
    {
        _service = service;
        _userManager = userManager;
    }

    [Authorize]
    public IActionResult Adopt(int petId)
    {
        var userId = _userManager.GetUserId(User);

        _service.CreateRequest(userId, petId);
        TempData["Msg"] = "Adopt request sent successfully!";
        return RedirectToAction("Index", "Pet");
    }

    [Authorize(Roles = "Admin")]
    public IActionResult Approve(int id)
    {
        _service.Approve(id);
        return RedirectToAction("Requests");
    }

    [Authorize(Roles = "Admin")]
    public IActionResult Reject(int id)
    {
        _service.Reject(id);
        return RedirectToAction("Requests");
    }
}