using System.ComponentModel.DataAnnotations;

namespace MovieWebAPI.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }    

        
    }
}