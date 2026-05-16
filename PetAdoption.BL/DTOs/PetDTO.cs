using System;
using System.Collections.Generic;
using System.Text;

namespace PetAdoption.BL.DTOs
{
    public class PetDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public int Age { get; set; }
        public string? Description { get; set; }
        public bool IsAdopted { get; set; }
        public string? ImageBase64 { get; set; }
        public int CategoryId { get; internal set; }
        public string Status { get; set; }
    }
}
