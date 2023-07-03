﻿using Entities.Models;
using Shared.DTOs.Question;

namespace Contracts;
public interface IQuestionRepository
{
    Task<Question> GetQuestionById(int questionId);
    Task<IEnumerable<QuestionWithIdDTO>> GetQuestions(string searchTearm, CancellationToken cancellationToken);
}
