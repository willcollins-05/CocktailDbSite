namespace CocktailDbSite.Domain.Models.DrinkModels;

public class Measurement
{
    public double Amount { get; set; }
    public string Unit { get; set; }

    public override string ToString()
    {
        return $"{Amount} {Unit}";
    }

    public string ToString(int scale)
    {
        return $"{Amount * scale} {Unit}";
    }

    public static Measurement? StringToMeasurementConvertion(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return null;

        var fullAlphabetString = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        
        int firstLetterIndex = input.IndexOfAny(fullAlphabetString.ToCharArray());

        if (firstLetterIndex == -1) // NO UNIT FOUND
        {
            return new Measurement()
            {
                Amount = ParseFullFractionToDecimal(input),
                Unit = String.Empty,
            };
        }

        string amountPart = input.Substring(0, firstLetterIndex).Trim();
        string unitPart = input.Substring(firstLetterIndex).Trim();

        return new Measurement()
        {
            Amount = ParseFullFractionToDecimal(amountPart),
            Unit = unitPart,
        };
    }

    private static double ParseFullFractionToDecimal(string amountStr)
    {
        if (string.IsNullOrWhiteSpace(amountStr)) return 0;

        if (amountStr.Trim().Contains(" ") && amountStr.Contains("/"))
        {
            var parts = amountStr.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length >= 2)
            {
                return double.Parse(parts[0]) + ParseFractionToDecimal(parts[1]);
            }
        }

        if (amountStr.Contains("/"))
        {
            return ParseFractionToDecimal(amountStr);
        }

        if (double.TryParse(amountStr, out var amount))
        {
            return amount;
        }

        return 0;
    }

    private static double ParseFractionToDecimal(string amountStr)
    {
        var parts = amountStr.Split('/');
        if (parts.Length == 2 &&
            double.TryParse(parts[0], out double num) &&
            double.TryParse(parts[1], out double den))
        {
            return num / den;
        }

        return 0;
    }
}