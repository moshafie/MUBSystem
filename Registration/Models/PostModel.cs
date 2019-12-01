using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.Models
{
    public class PostModel
    {
        [Key]
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Body { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    }
}
