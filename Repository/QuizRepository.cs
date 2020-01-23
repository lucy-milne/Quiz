using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class QuizRepository : RepositoryBase<Quiz>, IQuizRepository
    {
        public QuizRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateQuiz(Quiz quiz)
        {
            Create(quiz);
        }

        public void DeleteQuiz(Quiz quiz)
        {
            Delete(quiz);
        }

        public IEnumerable<Quiz> GetAllQuizzes()
        {
            return FindAll()
                .OrderBy(ow => ow.Name)
                .ToList();
        }

        public Quiz GetQuizById(Guid quizid)
        {
            return FindByCondition(quiz => quiz.Id.Equals(quizid))
                .FirstOrDefault();
        }
    }
}
