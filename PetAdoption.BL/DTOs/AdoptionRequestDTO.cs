using System;
using System.Collections.Generic;
using System.Text;

namespace PetAdoption.BL.DTOs
{
    public class AdoptionRequestDTO
    {
        
            public int Id { get; set; }

            public int PetId { get; set; }

            public string? PetName { get; set; }

            public string? UserEmail { get; set; }

            public string Status { get; set; }

            public DateTime RequestDate { get; set; }
        }
    }

