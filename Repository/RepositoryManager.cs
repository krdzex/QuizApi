using Contracts;
using Repository.Repositories;

namespace Repository;
public sealed class RepositoryManager : IRepositoryManager
{
    private readonly Lazy<IQuizRepository> _quizRepository;
    private readonly Lazy<IQuestionRepository> _questionRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _quizRepository = new Lazy<IQuizRepository>(() => new QuizRepository(repositoryContext));
        _questionRepository = new Lazy<IQuestionRepository>(() => new QuestionRepository(repositoryContext));

    }

    public IQuizRepository Quiz => _quizRepository.Value;
    public IQuestionRepository Question => _questionRepository.Value;
}
