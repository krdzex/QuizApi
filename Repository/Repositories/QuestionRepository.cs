using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.DTOs.Question;
using Shared.RequestFeatures;

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

    public async Task<PagedList<QuestionDTO>> GetQuestions(QuestionParameters questionParameters, CancellationToken cancellationToken)
    {
        IQueryable<Question> questionsQuery = _context
            .Questions
            .Search(questionParameters.SearchTerm)
            .Sort(questionParameters.OrderBy);

        var questionResponseQuery = questionsQuery
            .Select(q => new QuestionDTO
            {
                Id = q.Id,
                Text = q.Text,
                Answer = q.Answer,
            });

        var questions = await PagedList<QuestionDTO>.CreateAsync(questionResponseQuery, questionParameters.PageNumber, questionParameters.PageSize);

        return questions;
    }

    public async Task<bool> QuestionExists(int questionId, CancellationToken cancellationToken)
    {
        return await _context.Questions.AnyAsync(q => q.Id == questionId, cancellationToken);
    }
}
