using Contracts;
using Microsoft.EntityFrameworkCore;
using Shared.DTOs.Quiz;

namespace Repository.Repositories;
public class QuizRepository : IQuizRepository
{
    private readonly RepositoryContext _context;
    public QuizRepository(RepositoryContext repositoryContext)
    {
        _context = repositoryContext;
    }

    public async Task<IEnumerable<QuizNameDTO>> GetAllQuizNamesAsync(CancellationToken cancellationToken)
    {
        return await _context.Quizzes
            .Select(q => new QuizNameDTO
            {
                Id = q.Id,
                Name = q.Name
            })
            .ToListAsync(cancellationToken);
    }
}