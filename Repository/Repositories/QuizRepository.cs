using Contracts;
using Microsoft.EntityFrameworkCore;
using Shared.DTOs.Question;
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

    public async Task<QuizWithQuestionsDTO> GetQuizWithQuestionsAsync(int quizId, CancellationToken cancellationToken)
    {
        var quiz = await _context.Quizzes
            .Where(q => q.Id == quizId)
            .Select(q => new QuizWithQuestionsDTO
            {
                Id = q.Id,
                Name = q.Name,
                Questions = q.QuizQuestions.Select(qq => new QuestionDTO
                {
                    Text = qq.Question.Text,
                    Answer = qq.Question.Answer
                }).ToList()
            })
            .FirstOrDefaultAsync(cancellationToken);

        return quiz;
    }
}