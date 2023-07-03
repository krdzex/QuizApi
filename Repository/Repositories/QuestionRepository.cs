using Contracts;

namespace Repository.Repositories;
public class QuestionRepository : IQuestionRepository
{
    private readonly RepositoryContext _context;
    public QuestionRepository(RepositoryContext repositoryContext)
    {
        _context = repositoryContext;
    }
}
