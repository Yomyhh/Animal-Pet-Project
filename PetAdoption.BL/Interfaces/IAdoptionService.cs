using PetAdoption.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetAdoption.BL.Interfaces
{
    public interface IAdoptionService
    {
        public void CreateRequest(string userId, int petId);
        IEnumerable<AdoptionRequestDTO> GetAllRequests();
        void Approve(int id);
        void Reject(int id);
    }
}
