using Contracts;
using Repository.Repositories;

namespace Repository;
public sealed class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IQuizRepository> _quizRepository;
    private readonly Lazy<IQuestionRepository> _questionRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _quizRepository = new Lazy<IQuizRepository>(() => new QuizRepository(repositoryContext));
        _questionRepository = new Lazy<IQuestionRepository>(() => new QuestionRepository(repositoryContext));

    }

    public IQuizRepository Quiz => _quizRepository.Value;
    public IQuestionRepository Question => _questionRepository.Value;
    public async Task SaveAsync(CancellationToken cancellationToken) => await _repositoryContext.SaveChangesAsync(cancellationToken);

}
