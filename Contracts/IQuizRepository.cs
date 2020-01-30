using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Contracts
{
    public interface IQuizRepository : IRepositoryBase<Quiz>
    {
        IEnumerable<Quiz> GetAllQuizzes();
        IEnumerable<Quiz> GetOtherQuizzes(string username);
        IEnumerable<Quiz> GetUsersQuizzes(string username);
        Quiz GetQuizById(Guid quizid);
        void CreateQuiz(Quiz quiz);
        void DeleteQuiz(Quiz quiz);
    }
}
