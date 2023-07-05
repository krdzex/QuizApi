using Microsoft.EntityFrameworkCore;

namespace Shared.RequestFeatures;
public class PagedList<T>
{
	private PagedList(List<T> items, int page, int pageSize, int totalCount)
	{
		Items = items;
		CurrentPage = page;
		PageSize = pageSize;
		TotalCount = totalCount;
		TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
	}

	public List<T> Items { get; }
	public int CurrentPage { get; }
	public int PageSize { get; }
	public int TotalCount { get; }
	public int TotalPages { get; }

	public bool HasNextPage => CurrentPage < TotalPages;
	public bool HasPreviousPage => CurrentPage > 1;

	public static async Task<PagedList<T>> CreateAsync(IQueryable<T> query, int page, int pageSize)
	{
		var totalCount = await query.CountAsync();
		var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

		return new(items, page, pageSize, totalCount);
	}
}

