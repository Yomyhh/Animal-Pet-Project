using PetAdoption.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetAdoption.DAL.Interfaces
{
    public interface IPetRepo
    {
        IEnumerable<Pet> GetALL();
        Pet GetById(int id);

        void Add(Pet pet);

        void Update(Pet pet);

        void Delete(int id);

        void Save();
    }
}
