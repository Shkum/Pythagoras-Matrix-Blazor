namespace PythagorasMatrix.Blazor.Models;

public sealed class PythagorasResult
{
    public string[] Numbers { get; init; } = new string[9];
    public int Embodiment { get; init; }
    public int FirstNumber { get; init; }
    public int SecondNumber { get; init; }
    public int ThirdNumber { get; init; }
    public int FourthNumber { get; init; }
    public int[] Rows { get; init; } = new int[3];
    public int[] Columns { get; init; } = new int[3];
    public int DiagonalDown { get; init; }
    public int DiagonalUp { get; init; }
}
