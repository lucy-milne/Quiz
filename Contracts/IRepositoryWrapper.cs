namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IQuestionRepository Question { get; }
        IQuizRepository Quiz { get; }
        IUserRepository User { get;  }
        void Save();
    }
}