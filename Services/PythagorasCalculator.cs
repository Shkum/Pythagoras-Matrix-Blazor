using PythagorasMatrix.Blazor.Models;

namespace PythagorasMatrix.Blazor.Services;

public sealed class PythagorasCalculator
{
    public PythagorasResult Calculate(DateTime birthDate)
    {
        var day = birthDate.Day.ToString("00");
        var month = birthDate.Month.ToString("00");
        var year = birthDate.Year.ToString();
        var source = (day + month + year).Replace("0", "");
        var first = SumDigits(source);
        var second = SumDigits(first.ToString());
        var firstDayDigit = int.Parse(day.TrimStart('0')[0].ToString());
        var third = first - firstDayDigit * 2;
        var fourth = SumDigits(Math.Abs(third).ToString());
        var final = (source + first + second + third + fourth).Replace("0", "").Replace("-", "");

        var nums = Enumerable.Range(1, 9)
            .Select(i => new string((char)('0' + i), final.Count(c => c == '0' + i)))
            .ToArray();
        int L(int i) => nums[i - 1].Length;

        return new PythagorasResult
        {
            Numbers = nums,
            Embodiment = final.Length,
            FirstNumber = first,
            SecondNumber = second,
            ThirdNumber = third,
            FourthNumber = fourth,
            Rows = [L(1) + L(4) + L(7), L(2) + L(5) + L(8), L(3) + L(6) + L(9)],
            Columns = [L(1) + L(2) + L(3), L(4) + L(5) + L(6), L(7) + L(8) + L(9)],
            DiagonalDown = L(1) + L(5) + L(9),
            DiagonalUp = L(3) + L(5) + L(7)
        };
    }

    private static int SumDigits(string value) => value.Where(char.IsDigit).Sum(c => c - '0');
}
