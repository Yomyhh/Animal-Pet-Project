using Microsoft.EntityFrameworkCore;
using PetAdoption.BL.DTOs;
using PetAdoption.BL.Interfaces;
using PetAdoption.DAL.Interfaces;
using PetAdoption.DAL.Models;

namespace PetAdoption.BL.Services
{
    public class AdoptionService : IAdoptionService
    {
        private readonly IAdoptionRepo _repo;

        public AdoptionService(IAdoptionRepo repo)
        {
            _repo = repo;
        }


        public void Approve(int id)
        {
            var request = _repo.GetById(id);

            if (request == null)
                return;

            request.Status = "Approved";

            request.Pet.Status = "Sold Out";

            _repo.AddNotification(new Notification
            {
                UserId = request.UserId,
                Message = $"Your adoption request for {request.Pet.Name} has been APPROVED 🎉",
                IsRead = false
            });

            _repo.Save();
        }

        public void Reject(int id)
        {
            var request = _repo.GetById(id);

            if (request == null)
                return;

            request.Status = "Rejected";

            _repo.AddNotification(new Notification
            {
                UserId = request.UserId,
                Message = $"Your adoption request for {request.Pet?.Name} has been REJECTED ❌",
                IsRead = false
            });

            _repo.Save();
        }

        public void CreateRequest(string userId, int petId)
        {
            var request = new AdoptionRequest
            {
                UserId = userId,
                PetId = petId,
                Status = "Pending",
                RequestDate = DateTime.Now
            };

            _repo.Add(request);
            _repo.Save();
        }

        public IEnumerable<AdoptionRequestDTO> GetAllRequests()
        {
            return _repo.GetAll()
                .Include(r => r.Pet)
                .Include(r => r.User)
                .Select(r => new AdoptionRequestDTO
                {
                    Id = r.Id,
                    PetName = r.Pet != null ? r.Pet.Name : "",
                    UserEmail = r.User != null ? r.User.Email : "",
                    Status = r.Status,
                    RequestDate = r.RequestDate
                });
        }
    }
}