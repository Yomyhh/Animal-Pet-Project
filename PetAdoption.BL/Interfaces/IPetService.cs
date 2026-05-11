using PetAdoption.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetAdoption.BL.Interfaces
{
    public interface IPetService
    {

        IEnumerable<PetDTO> GetAllPets();
        PetDTO? GetPetById(int id);
        void AddPet(CreatePetDTO dto);
        void UpdatePet(int id, CreatePetDTO dto);
        void DeletePet(int id);
        IEnumerable<PetDTO> GetAvailablePets();
    }
}
