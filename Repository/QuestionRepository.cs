using System;
using System.Collections.Generic;
using System.Linq;
using Entities.Models;
using Contracts;
using Entities;

namespace Repository
{
    public class QuestionRepository : RepositoryBase<Questions>, IQuestionRepository
    {
        public QuestionRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
        {
        }

        public IEnumerable<Questions> GetAllQuestions()
        {
            return FindAll()
                .OrderBy(ow => ow.Question)
                .ToList();
        }

        public IEnumerable<Questions> GetQuestionsForQuiz(Guid quizid)
        {
            return FindByCondition(question => question.QuizId.Equals(quizid)).ToList();
        }

        public void CreateQuestion(Questions question)
        {
            Create(question);
        }

        public Questions GetQuestionById(Guid id)
        {
            return FindByCondition(question => question.Id.Equals(id))
                .FirstOrDefault();
        }

        public void DeleteQuestion(Questions question)
        {
            Delete(question);
        }
    }
}