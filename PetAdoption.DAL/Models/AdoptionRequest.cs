using System;
using System.Collections.Generic;
using System.Text;

namespace PetAdoption.DAL.Models
{
    public class AdoptionRequest
    {
        //1 user----- *adoptionrequest and  1 pet---------many pets

        public int Id { get; set; }
        public string? UserId { get; set; }

        public ApplicationUser? User { get; set; }

        public Pet? Pet { get; set; }

        public int PetId { get; set; }

        public DateTime RequestDate { get; set; } = DateTime.Now;

        public string Status { get; set; } = "Pending";
    }
}
