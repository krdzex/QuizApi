using Contracts;
using Entities.Models;

namespace Repository.Repositories;
public class QuestionRepository : IQuestionRepository
{
    private readonly RepositoryContext _context;
    public QuestionRepository(RepositoryContext repositoryContext)
    {
        _context = repositoryContext;
    }

    public async Task<Question> GetQuestionById(int questionId)
    {
        var question = await _context.Questions.FindAsync(questionId);

        return question;
    }
}
