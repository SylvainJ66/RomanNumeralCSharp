using FluentAssertions;

namespace RomanNumeralTests;

public class ConvertToRomanNumeralShould
{
    [Theory]
    [InlineData(1, "I")]
    [InlineData(2, "II")]
    [InlineData(3, "III")]
    [InlineData(4, "IV")]
    [InlineData(5, "V")]
    [InlineData(6, "VI")]
    [InlineData(9, "IX")]
    [InlineData(10, "X")]
    [InlineData(11, "XI")]
    [InlineData(14, "XIV")]
    [InlineData(15, "XV")]
    [InlineData(16, "XVI")]
    [InlineData(20, "XX")]
      public void Parse_arabic_to_roman(int arabic, string roman) 
        => RomanNumeralConverter.Parse(arabic).Should().Be(roman);

}

public static class RomanNumeralConverter
{
    private static readonly Dictionary<int,string> Romans = new()
    { {10, "X"}, {9, "IX"}, {5, "V"}, {4, "IV"}, {1, "I"} };

    public static string Parse(int arabicNumber)
    {
        var result = "";

        foreach(var item in Romans)
        {
            while (arabicNumber >= item.Key)
            {
                result += Romans[item.Key];
                arabicNumber -= item.Key;
            }
        }

        return result;
    }
}

// 1 nil
// 2 nil -> constant
// 4 Constant -> variable
// 5 statement -> statements
// 6 unconditional -> conditional
// 7 variable -> array
// 8 array -> collection
// 9 statement -> tail recursion
// 10 if -> while