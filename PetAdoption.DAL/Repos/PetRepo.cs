using Microsoft.EntityFrameworkCore;
using PetAdoption.DAL.Interfaces;
using PetAdoption.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetAdoption.DAL.Repos
{
    public class PetRepo : IPetRepo
    {
       private readonly AppDbContext _context;
        
        public PetRepo(AppDbContext context)
        {
            _context= context ;
        }
        public void Add(Pet pet) => _context.Pets.Add(pet);

        public void Delete(int id)
        {
            var pet = GetById(id);
            if (pet != null)
            _context.Pets.Remove(pet);
        }
        public void Update(Pet pet) => _context.Pets.Update(pet); 
        
       
        

        public IEnumerable<Pet> GetALL() => _context.Pets.ToList();



        public Pet GetById(int id) => _context.Pets.Find(id);




        public void Save() => _context.SaveChanges();


    }
}
