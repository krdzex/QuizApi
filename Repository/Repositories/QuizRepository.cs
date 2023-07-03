using Contracts;

namespace Repository.Repositories;
public class QuizRepository : IQuizRepository
{
    private readonly RepositoryContext _context;
    public QuizRepository(RepositoryContext repositoryContext)
    {
        _context = repositoryContext;
    }
}