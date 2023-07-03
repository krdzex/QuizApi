﻿using Contracts;
using Entities.Models;
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

    public async Task<Quiz> GetQuizById(int quizId)
    {
        var quiz = await _context.Quizzes.FindAsync(quizId);

        return quiz;
    }

    public async Task<bool> QuizExists(int quizId)
    {
        return await _context.Quizzes.AnyAsync(q => q.Id == quizId);
    }

    public async Task<bool> RemoveQuestionFromQuiz(int quizId, int questionId, CancellationToken cancellationToken)
    {
        var quiz = await _context.Quizzes.Include(q => q.QuizQuestions).SingleOrDefaultAsync(q => q.Id == quizId, cancellationToken);

        var questionToRemove = quiz.QuizQuestions.FirstOrDefault(q => q.QuestionId == questionId);

        if (questionToRemove == null)
        {
            return false;
        }

        quiz.QuizQuestions.Remove(questionToRemove);

        return true;
    }

    public void Create(Quiz quiz)
    {
        _context.Quizzes.Add(quiz);
    }

    public void Delete(Quiz quiz)
    {
        _context.Quizzes.Remove(quiz);
    }
}