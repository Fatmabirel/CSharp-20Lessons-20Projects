using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4_EntityFrameworkCodeFirstMovieProject.DAL.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual Category Category { get; set; }
        
    }
}
