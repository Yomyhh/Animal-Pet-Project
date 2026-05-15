using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace PetAdoption.DAL.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<AdoptionRequest> AdoptionRequests { get; set; }

    }


}
