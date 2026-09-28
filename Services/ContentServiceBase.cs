using PythagorasMatrix.Blazor.Models;

namespace PythagorasMatrix.Blazor.Services;

public abstract class ContentServiceBase : IContentService
{
    protected ContentRoot? Content;

    public abstract Task EnsureLoadedAsync();

    public string Different(int index, string lang) => Value(Content!.DifferentInfo.ElementAtOrDefault(index), lang);
    public string Line(int index, string lang) => Value(Content!.LinesInfo.ElementAtOrDefault(index), lang);
    public string About(int index, string lang) => Value(Content!.AboutInfo.ElementAtOrDefault(index), lang);
    public string General(string lang) => string.Join("<br><br>", Content!.GeneralInfo.Select(x => Value(x, lang)));

    public string Full(string key, string lang)
    {
        var row = Content!.FullInfo.FirstOrDefault(x => x.Name == key);
        return Value(row, lang);
    }

    public string MatrixCell(string value, int digit, string lang)
    {
        var len = value.Length;
        var key = digit switch
        {
            1 => len == 0 ? "1" : len < 6 ? value : "111111",
            2 => len == 0 ? "2-0" : len < 4 ? value : "2222",
            3 => len == 0 ? "3-0" : len < 4 ? value : "3333",
            4 => len == 0 ? "4-0" : len < 2 ? value : "44",
            5 => len == 0 ? "5-0" : len < 3 ? value : "555",
            6 => len == 0 ? "6-0" : len < 3 ? value : "666",
            7 => len == 0 ? "7-0" : len < 3 ? value : "777",
            8 => len == 0 ? "8-0" : len < 2 ? value : "88",
            9 => len == 0 ? "9" : len < 3 ? value : "999",
            _ => ""
        };
        return Full(key, lang);
    }

    protected static string Value(ContentRow? row, string lang)
    {
        if (row is null) return "";
        var text = lang switch
        {
            "de" => row.InfoDe,
            "ua" => row.InfoUa,
            "ru" => row.InfoRu,
            _ => row.InfoEn
        };
        return (text ?? "").Replace("&apos;", "'");
    }
}
