using System;
using System.Collections;
using System.Collections.Generic;
using Entities.Models;


namespace Contracts
{
    public interface IQuestionRepository : IRepositoryBase<Questions>
    {
        IEnumerable<Questions> GetAllQuestions();
        IEnumerable<Questions> GetQuestionsForQuiz(Guid questionid);
        void CreateQuestion(Questions question);
        Questions GetQuestionById(Guid id);
        void DeleteQuestion(Questions question);
    }
}
