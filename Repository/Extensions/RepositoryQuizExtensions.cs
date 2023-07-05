using Entities.Models;
using Repository.Extensions.Utility;
using System.Linq.Dynamic.Core;

namespace Repository.Extensions;
public static class RepositoryQuizExtensions
{
    public static IQueryable<Quiz> Search(this IQueryable<Quiz> quizzes, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return quizzes;

        var lowerCaseTerm = searchTerm.Trim().ToLower();

        return quizzes.Where(e => e.Name.ToLower().Contains(lowerCaseTerm));
    }

    public static IQueryable<Quiz> Sort(this IQueryable<Quiz> quizzes, string orderByQueryString)
    {
        if (string.IsNullOrWhiteSpace(orderByQueryString))
            return quizzes.OrderBy(e => e.Name);

        var orderQuery = OrderQueryBuilder.CreateOrderQuery<Quiz>(orderByQueryString);

        if (string.IsNullOrWhiteSpace(orderQuery))
            return quizzes.OrderBy(e => e.Name);

        return quizzes.OrderBy(orderQuery);
    }
}
