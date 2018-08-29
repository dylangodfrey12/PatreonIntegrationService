using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiIntegration.Models
{
    public class LoginDto
    {
        [Key]
        public long LoginId { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        public UserProfileDto UsepProfileDto { get; set; }
    }

    public class LoginResponseDto
    {
        [Key]
        public Guid Token { get; set; }
        public string Response { get; set; }
    }

}
