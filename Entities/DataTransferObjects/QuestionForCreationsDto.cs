using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class QuestionForCreationsDto
    {
        public string question { get; set; }
        public string correctAnswer { get; set; }
        public string wrongAnswer1 { get; set; }
        public string wrongAnswer2 { get; set; }
        public string wrongAnswer3 { get; set; }
        public string Quizid { get; set; }
    }
}
