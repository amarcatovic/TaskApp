using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskApp.Photos.Data.Models
{
    public class Photo
    {
        public Guid Id { get; set; }

        public int UserId { get; set; }

        public string PhotoUrl { get; set; }

    }
}
