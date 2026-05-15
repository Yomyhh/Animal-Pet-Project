using PetAdoption.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetAdoption.DAL.Interfaces
{
    public interface IAdoptionRepo
    {
        void Add(AdoptionRequest request);
        void Save();
        IQueryable<AdoptionRequest> GetAll();
        void Update(AdoptionRequest request);
        AdoptionRequest GetById(int id);
    }
}
