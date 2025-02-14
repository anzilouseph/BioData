using System.ComponentModel.DataAnnotations;

namespace BioDataJWT.Dto
{
    public class UserForCreationDto
    {

        [Required(ErrorMessage = "Name is required")]
        public string nameOfUser { get; set; }

        [Required(ErrorMessage = "Age is required")]
        public int? ageOfUser { get; set; }


        public string addressOfUser { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string emailOfUser { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string passwordOfUser { get; set; }
    }
}
