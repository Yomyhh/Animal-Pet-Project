using Microsoft.EntityFrameworkCore;
using PetAdoption.DAL.Interfaces;
using PetAdoption.DAL.Models;

namespace PetAdoption.DAL.Repos
{
    public class AdoptionRepo : IAdoptionRepo
    {
        private readonly AppDbContext _context;

        public AdoptionRepo(AppDbContext context)
        {
            _context = context;
        }

        public void Add(AdoptionRequest request)
        {
            _context.AdoptionRequests.Add(request);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public IQueryable<AdoptionRequest> GetAll()
        {
            return _context.AdoptionRequests
                .Include(x => x.Pet)
                .Include(x => x.User);
        }

        public void Update(AdoptionRequest request)
        {
            _context.AdoptionRequests.Update(request);
        }

        public AdoptionRequest GetById(int id)
        {
            return _context.AdoptionRequests
                .Include(x => x.Pet)
                .Include(x => x.User)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}