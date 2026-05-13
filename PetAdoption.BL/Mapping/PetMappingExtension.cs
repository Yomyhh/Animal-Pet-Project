using PetAdoption.BL.DTOs;
using PetAdoption.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetAdoption.BL.Mapping
{
    public static class PetMappingExtension
    {
   
        public static Pet ToEntity(this CreatePetDTO dto)
        {
            return new Pet
            {
                Name = dto.Name,
                Type = dto.Type,
                Age = dto.Age,
                Description = dto.Description,
                ImageBase64 = dto.ImageBase64,
                CategoryId= dto.CategoryId
            };
        }

        public static PetDTO ToDTO(this Pet pet)
        {
            return new PetDTO
            {
                Id = pet.Id,
                Name = pet.Name,
                Type = pet.Type,
                Age = pet.Age,
                Description = pet.Description,
                ImageBase64 = pet.ImageBase64,
                CategoryId= pet.CategoryId
            };
        
        }
    }
}
