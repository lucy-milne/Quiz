using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IQuestionRepository _question;
        private IQuizRepository _quiz;

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public IQuestionRepository Question
        {
            get
            {
                if (_question == null)
                {
                    _question = new QuestionRepository(_repoContext);
                }

                return _question;
            }
        }

        public IQuizRepository Quiz
        {
            get
            {
                if (_quiz == null)
                {
                    _quiz = new QuizRepository(_repoContext);
                }

                return _quiz;
            }
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}