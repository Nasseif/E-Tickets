using eTickets.Repository;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Actor : IEntityBase
    {
        public int Id { get; set; }
        [Display(Name ="Full Name")]
        [Required(ErrorMessage = " Name Is Required ")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 50 chars")]
        public string FullName { get; set; }
        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = " Profile Picture Is Required ")]
        public string ProfilePictureUrl { get; set; }
        [Display(Name = "Biography")]
        [Required(ErrorMessage = " Biography Is Required ")]
        public string Bio { get; set; }
        public ICollection<Actor_Movie> actor_Movies { get; set; }  
        
    }
}
