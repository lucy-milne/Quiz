﻿using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public class QuizForCreationDto
    {
        public string Name { get; set; }
        public string Username { get; set; }
    }
}