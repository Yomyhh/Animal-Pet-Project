using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetAdoption.BL.Interfaces;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly IPetService _petService;
    private readonly IAdoptionService _adoptionService;

    public AdminController(IPetService petService, IAdoptionService adoptionService)
    {
        _petService = petService;
        _adoptionService = adoptionService;
    }

    public IActionResult Dashboard()
    {
        return View();
    }

    public IActionResult Pets()
    {
        return RedirectToAction("Index", "Pet");
    }
    public IActionResult Requests()
    {
        var requests = _adoptionService.GetAllRequests();
        return View(requests);
    }
public IActionResult Approve(int id)
        {
            _adoptionService.Approve(id);

            return RedirectToAction("Requests");
        }

        public IActionResult Reject(int id)
        {
            _adoptionService.Reject(id);

            return RedirectToAction("Requests");
        }
}

