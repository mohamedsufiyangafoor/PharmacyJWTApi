using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyJWTApi.Models
{
    public class UserDetail
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int User_id { get; set; }

        [DisplayName("Name")]
        [StringLength(40, MinimumLength = 5)]
        [Required(ErrorMessage = "First Name can`t be blank")]
        public string User_name { get; set; }

        [DisplayName("Email")]
        [EmailAddress]
        [Required(ErrorMessage = "Email id can't be blank")]
        public string Email_id { get; set; }

        [DisplayName("Password")]
       // [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$")]
        [Required(ErrorMessage = "Password can`t be blank")]
        public string Password { get; set; }

        [DisplayName("PhoneNumber")]
        [RegularExpression("^[5-9][0-9]{9}$")]
        [Required(ErrorMessage = "Enter Correct Phone Number")]
        public string Mobile_no { get; set; }

        [DisplayName("Address")]
        [StringLength(50, MinimumLength = 5)]
        [Required(ErrorMessage = "First Name can`t be blank")]
        public string Address { get; set; }
        [DisplayName("Role")]
        public string Role { get; set; }
        [DisplayName("Age")]
        public int Age { get; set; }

        

    }
}
