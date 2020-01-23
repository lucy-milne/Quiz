using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("Quiz")]
    public class Quiz
    {
        [Column("Quizid")]
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
