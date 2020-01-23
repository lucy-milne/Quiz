namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IQuestionRepository Question { get; }
        IQuizRepository Quiz { get; }
        void Save();
    }
}