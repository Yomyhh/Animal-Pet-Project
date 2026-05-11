using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace PetAdoption.BL.DTOs
{
    public class CreatePetDTO
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Type { get; set; }


        [Range(0, 30)]
        public int Age { get; set; }

        public string? Description { get; set; }
        public IFormFile? ImageFile { get; set; }
        public string? ImageBase64 { get; set; }
    }
}
