using eTicketAPP.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTicketAPP.Models
{
    public class Actor:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage ="Profile picture is required")]
        public string ProfilePictureUrl { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "full name is required")]
        [StringLength(50,MinimumLength =3,ErrorMessage ="Full Name must between 3 and 50 chars")]
        public string FullName { get; set; }
        [Display(Name = "Biographie")]
        [Required(ErrorMessage = "Biography is required")]

        public string Bio { get; set; }
        public List<Actor_Movie> Actors_Movies { get; set; }
    }
}

