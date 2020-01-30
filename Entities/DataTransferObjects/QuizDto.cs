using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class QuizDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
    }
}
