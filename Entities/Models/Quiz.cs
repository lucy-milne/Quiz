using System;
using System.ComponentModel.DataAnnotations.Schema;

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
