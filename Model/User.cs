using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    //Data Annotations
    public class User
    {
        [Required]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Please enter your name.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter your surname.")]
        public string UserSurname { get; set; }

        [Required(ErrorMessage = "Please enter your email.")]
        public string UserEmail { get; set; }

    }
}
