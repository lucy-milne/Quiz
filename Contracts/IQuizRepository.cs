using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Contracts
{
    public interface IQuizRepository : IRepositoryBase<Quiz>
    {
        IEnumerable<Quiz> GetAllQuizzes();
        Quiz GetQuizById(Guid quizid);
        void CreateQuiz(Quiz quiz);
        void DeleteQuiz(Quiz quiz);
    }
}
