using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace e_diary.Database.Models
{
    public class DBUser
    {

        //Primary Key
        [Key]
        public Guid UserId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public bool IsActive { get; set; }

    }
}
