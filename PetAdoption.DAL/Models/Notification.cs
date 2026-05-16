using System;
using System.Collections.Generic;
using System.Text;

namespace PetAdoption.DAL.Models
{  
    public class Notification
    {
            public int Id { get; set; }

            public string UserId { get; set; }

            public string Message { get; set; }

            public bool IsRead { get; set; } = false;

            public DateTime Date { get; set; } = DateTime.Now;
        }
    }

