using System;
using System.Collections.Generic;
using System.Text;

namespace PetAdoption.DAL.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Pet> Pets { get; set; }


    }
}
