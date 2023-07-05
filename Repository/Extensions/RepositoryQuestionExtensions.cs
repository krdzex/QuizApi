using Entities.Models;
using Repository.Extensions.Utility;
using System.Linq.Dynamic.Core;

namespace Repository.Extensions;
public static class RepositoryQuestionExtensions
{
    public static IQueryable<Question> Search(this IQueryable<Question> questions, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return questions;

        var lowerCaseTerm = searchTerm.Trim().ToLower();

        return questions.Where(e => e.Text.ToLower().Contains(lowerCaseTerm));
    }

    public static IQueryable<Question> Sort(this IQueryable<Question> questions, string orderByQueryString)
    {
        if (string.IsNullOrWhiteSpace(orderByQueryString))
            return questions.OrderBy(e => e.Text);

        var orderQuery = OrderQueryBuilder.CreateOrderQuery<Question>(orderByQueryString);

        if (string.IsNullOrWhiteSpace(orderQuery))
            return questions.OrderBy(e => e.Text);

        return questions.OrderBy(orderQuery);
    }
}
