using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.DTOs.Question;

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

    public async Task<IEnumerable<QuestionWithIdDTO>> GetQuestions(string searchTearm, CancellationToken cancellationToken)
    {
        var questions = await _context.Questions
            .Where(q => q.Text.Contains(searchTearm))
            .Select(q => new QuestionWithIdDTO
            {
                Id = q.Id,
                Text = q.Text,
                Answer = q.Answer,
            })
            .ToListAsync(cancellationToken);

        return questions;
    }

    public async Task<bool> QuestionExists(int questionId)
    {
        return await _context.Questions.AnyAsync(q => q.Id == questionId);
    }
}
