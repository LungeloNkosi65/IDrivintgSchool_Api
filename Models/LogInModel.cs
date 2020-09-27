using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class LogInModel
    {
        [Key]
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RefereshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
