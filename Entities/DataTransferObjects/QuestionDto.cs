using System;

namespace Entities.DataTransferObjects
{
    public class QuestionDto
    {
        public Guid Id { get; set; }
        public string Question { get; set;  }
        public string CorrectAnswer { get; set; }
        public string WrongAnswer1 { get; set; }
        public string WrongAnswer2 { get; set; }
        public string WrongAnswer3 { get; set; }
        public Guid Quizid { get; set; }
    }
}