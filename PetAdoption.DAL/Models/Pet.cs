using System;
using System.Collections.Generic;
using System.Text;

namespace PetAdoption.DAL.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public int Age { get; set; }
        public string? Description { get; set; }
        public bool IsAdopted { get; set; }
        public string? ImageBase64 { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
       
        public string Status { get; set; }= "Available";
        public ICollection<AdoptionRequest> AdoptionRequests { get; set; }

    }
}
