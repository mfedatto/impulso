namespace Agilize.ConfigProvider.Domain.Wrappers;

public static class PagedListWrapperExtensions
{
    public static PagedListWrapper<T> WrapUp<T>(
        this IEnumerable<T>? payload,
        int skip = 0,
        int? limit = null,
        int? total = null)
    {
        int count = payload?.Count() ?? 0;
        
        return new PagedListWrapper<T>(
            total: total ?? count,
            skip: skip,
            limit: limit,
            count: count,
            payload: payload ?? Array.Empty<T>());
    }
}
