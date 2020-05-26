namespace Food_ordering_system_PROJECT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    public partial class User
    {
        public int UserID { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Enter your name")]
        public string name { get; set; }

        [Required(ErrorMessage = "Enter your Passowrd")]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required(ErrorMessage = "Conferm your Passowrd")]
        [DisplayName("Confirm Passowrd")]
        [DataType(DataType.Password)]
        [Compare("password")]
        public string Confirmpassowrd { get; set; }

        [Required(ErrorMessage = "Enter your BithDate")]
        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public System.DateTime birthdate { get; set; }

        [Required(ErrorMessage = "Enter your E-mail")]
        [DisplayName("E-mail")]
        [DataType(DataType.EmailAddress)]
        public string e_mail { get; set; }

        public string LoginErrorMessege { get; set; }
    }
}
