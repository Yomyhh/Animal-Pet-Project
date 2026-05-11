using PetAdoption.BL.DTOs;
using PetAdoption.BL.Interfaces;
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

            var pet = new Pet
            {
                Name = dto.Name,
                Type = dto.Type,
                Age = dto.Age,
                Description = dto.Description,
               ImageBase64 = imageBase64,
                IsAdopted = false,

            };
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
            return _petRepo.GetALL().Select(p => new PetDTO
            {
                Id = p.Id,
                Name = p.Name,
                Type = p.Type,
                Age = p.Age,
                IsAdopted = p.IsAdopted,
                ImageBase64 = p.ImageBase64
            });
        }

        public IEnumerable<PetDTO> GetAvailablePets()
        {

            return _petRepo.GetALL()
                .Where(p => !p.IsAdopted)
                .Select(p => new PetDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Type = p.Type,
                    Age = p.Age,
                    IsAdopted = p.IsAdopted,
                    ImageBase64 = p.ImageBase64
                });
        }

        public PetDTO GetPetById(int id)
        {
            var P = _petRepo.GetById(id);
            if (P == null)
                return null;

            return new PetDTO
            {
                Id = P.Id,
                Name = P.Name,
                Type = P.Type,
                Age = P.Age,
                IsAdopted = P.IsAdopted,
                ImageBase64 = P.ImageBase64
            };
                 
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
