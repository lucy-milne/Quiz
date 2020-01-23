using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities.Models
{
    [Table("Question")]
    public class Questions
    {
        [Column("Questionid")]
        public Guid Id { get; set; }

        public string Question { get; set; }

        public string CorrectAnswer { get; set; }
        public string WrongAnswer1 { get; set; }
        public string WrongAnswer2 { get; set; }
        public string WrongAnswer3 { get; set; }
        public Guid QuizId { get; set; }
    }
}