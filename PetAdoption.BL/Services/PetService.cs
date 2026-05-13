using PetAdoption.BL.DTOs;
using PetAdoption.BL.Interfaces;
using PetAdoption.BL.Mapping;
using PetAdoption.DAL.Interfaces;
using PetAdoption.DAL.Models;
using PetAdoption.DAL.Repos;
using System;
using System.Collections.Generic;
using System.Net.Cache;
using System.Text;

namespace PetAdoption.BL.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepo _petRepo;

        public PetService(IPetRepo petRepo)
        {
            _petRepo = petRepo;
        }
        public void AddPet(CreatePetDTO dto)

        {
            //iMAGE 
            string? imageBase64 = null;
            if (dto.ImageFile != null && dto.ImageFile.Length > 0)
            {
                using var ms = new MemoryStream();
                dto.ImageFile.CopyTo(ms);
                var bytes = ms.ToArray();
                imageBase64 = Convert.ToBase64String(bytes);
            }


            var pet = dto.ToEntity();

            pet.ImageBase64 = imageBase64;
            pet.IsAdopted = false;

            
            _petRepo.Add(pet);
            _petRepo.Save();
        }

        public void DeletePet(int id)
        {
            _petRepo.Delete(id);
            _petRepo.Save();

        }

        public IEnumerable<PetDTO> GetAllPets()
        {
            return _petRepo.GetALL().Select(p => p.ToDTO());
            
        }

        public IEnumerable<PetDTO> GetAvailablePets()
        {

            return _petRepo.GetALL()
                .Where(p => !p.IsAdopted)
                .Select(p => p.ToDTO());
        }

        public PetDTO GetPetById(int id)
        {
            var P = _petRepo.GetById(id);
            if (P == null)
                return null;

            return P.ToDTO();

        }

        public void UpdatePet(int id, CreatePetDTO dto)
        {
            var pet = _petRepo.GetById(id);
            if (dto.ImageFile != null && dto.ImageFile.Length > 0)
            {
                using var ms = new MemoryStream();
                dto.ImageFile.CopyTo(ms);
                pet.ImageBase64 = Convert.ToBase64String(ms.ToArray());
            }
            else
            {
                
                pet.ImageBase64 = dto.ImageBase64;
            }

            pet.Name = dto.Name;
            pet.Type = dto.Type;
            pet.Age = dto.Age;
            pet.Description = dto.Description;

            _petRepo.Update(pet);
            _petRepo.Save();
            _petRepo.Update(pet);
            _petRepo.Save();
        }


    }
}
