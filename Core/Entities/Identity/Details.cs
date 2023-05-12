using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Identity
{
    public class Details
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Passport { get; set; }
        public string Citizenship { get; set; }
        
        [Required]
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}