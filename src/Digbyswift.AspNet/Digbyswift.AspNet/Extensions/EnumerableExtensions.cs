using Microsoft.AspNetCore.Mvc.Rendering;

namespace Digbyswift.AspNet.Extensions;

public static class EnumerableExtensions
{
    #region ToSelectList

    public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, string> text, Func<T, string> value)
    {
        return enumerable.Select(item => new SelectListItem { Text = text(item), Value = value(item) });
    }

    public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, string> text, Func<T, object> value)
    {
        return enumerable.Select(item => new SelectListItem { Text = text(item), Value = value(item).ToString() });
    }

    public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, string> text, Func<T, object> value, Func<T, string> groupTitle)
    {
        return ToSelectList(enumerable, text, value, groupTitle, null);
    }

    public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, string> text, Func<T, object> value, Func<T, string> groupTitle, Func<T, bool>? selected)
    {
        var groups = enumerable.DistinctBy(groupTitle).Select(x => new SelectListGroup { Name = groupTitle(x) }).ToList();

        return enumerable.Select(item => new SelectListItem
        {
            Text = text(item),
            Value = value(item).ToString(),
            Group = groups.First(g => g.Name == groupTitle(item)),
            Selected = selected?.Invoke(item) ?? false
        });
    }

    public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, string> text, Func<T, string> value, Func<T, bool> selected)
    {
        return enumerable.Select(item => new SelectListItem { Text = text(item), Value = value(item), Selected = selected(item) });
    }

    public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, string> text, Func<T, int> value, Func<T, bool> selected)
    {
        return enumerable.Select(item => new SelectListItem { Text = text(item), Value = value(item).ToString(), Selected = selected(item) });
    }

    public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, string> text, Func<T, string> value, string defaultText)
    {
        return GetDefaultSelectListItem(defaultText)
            .Concat(enumerable.Select(item => new SelectListItem { Text = text(item), Value = value(item) }))
            .ToList();
    }

    public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, string> text, Func<T, int> value, string defaultText)
    {
        return GetDefaultSelectListItem(defaultText)
            .Concat(enumerable.Select(item => new SelectListItem { Text = text(item), Value = value(item).ToString() }))
            .ToList();
    }

    private static IEnumerable<SelectListItem> GetDefaultSelectListItem(string? defaultText = null)
    {
        yield return new SelectListItem { Text = defaultText, Value = String.Empty };
    }

    #endregion
}
