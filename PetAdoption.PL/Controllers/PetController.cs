using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetAdoption.BL.DTOs;
using PetAdoption.BL.Interfaces;

namespace PetAdoption.PL.Controllers
{
    public class PetController : Controller
    {
        private readonly IPetService _petService;

    
        public PetController(IPetService petService)
        {
            _petService = petService;
          
        }

        public IActionResult Index()
        {
            var pets = _petService.GetAvailablePets();
            return View(pets);
        }

        public IActionResult Details(int id)
        {
            var pet = _petService.GetPetById(id);
            if (pet == null) return NotFound();
            return View(pet);
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreatePetDTO dto)
        {
            if (ModelState.IsValid)
            {
                _petService.AddPet(dto);
                return RedirectToAction("Index");
            }
            return View(dto);
        }
        [Authorize]
        public IActionResult Edit(int id)
        {
            var pet = _petService.GetPetById(id);
            if (pet == null) return NotFound();

            var dto = new CreatePetDTO
            {
                Name = pet.Name,
                Type = pet.Type,
                Age = pet.Age,
                ImageBase64= pet.ImageBase64,                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
                Description = pet.Description
            };
            return View(dto);
        }
                 
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CreatePetDTO dto)
        {
            if (ModelState.IsValid)
            {
                _petService.UpdatePet(id, dto);
                return RedirectToAction("Index");
            }
            return View(dto);
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            var pet = _petService.GetPetById(id);
            if (pet == null) return NotFound();
            return View(pet);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _petService.DeletePet(id);
            return RedirectToAction("Index");
        }
    }
}