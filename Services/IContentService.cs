namespace PythagorasMatrix.Blazor.Services;

public interface IContentService
{
    Task EnsureLoadedAsync();
    string Different(int index, string lang);
    string Line(int index, string lang);
    string About(int index, string lang);
    string General(string lang);
    string Full(string key, string lang);
    string MatrixCell(string value, int digit, string lang);
}
