using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("QuizUser")]
    public class User
    {
        [Column("UserName")]
        public string Id { get; set; }

        public string Password { get; set; }
    }
}
