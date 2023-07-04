﻿using Contracts;
using MediatR;
using Shared.DTOs.Question;
using Shared.Result;

namespace Application.Core.Question.Queries.GetQuestions;
internal sealed class GetQuestionsHandler : IRequestHandler<GetQuestionsQuery, Result<List<QuestionDTO>>>
{
    private readonly IRepositoryManager _repository;

    public GetQuestionsHandler(IRepositoryManager repository)
    {
        _repository = repository;
    }

    public async Task<Result<List<QuestionDTO>>> Handle(GetQuestionsQuery request, CancellationToken cancellationToken)
    {
        var questions = await _repository.Question.GetQuestions(request.SearchTerm, cancellationToken);

        return questions.ToList();
    }
}
