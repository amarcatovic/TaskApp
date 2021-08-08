using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskApp.Photos.Data.Shared;

namespace TaskApp.Photos.Data.Models
{
    public class Photo : IEntity
    {
        public Guid Id { get; set; }

        public int UserId { get; set; }

        public string PhotoUrl { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public Photo()
        {
            DateCreated = DateTime.Now;
        }
    }
}
