namespace Contracts;
public interface IRepositoryManager
{
    IQuizRepository Quiz { get; }
    IQuestionRepository Question { get; }
}