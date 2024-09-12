namespace App;

public static class IOHandler
{
    private const string InputFileName = "INPUT.TXT";
    private const string OutputFileName = "OUTPUT.TXT";

    public static (int Sum, int DigitsCount) ReadNumbersFromFile()
    {
        if (!File.Exists(InputFileName))
        {
            throw new Exception($"Файл {InputFileName} не було знайдено.");
        }

        var lines = File.ReadAllLines(InputFileName).Select(line => line.Trim())
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .ToArray();
        if (lines.Length == 0)
        {
            throw new Exception("Файл не містить жодного тексту");
        }

        if (lines.Length != 1)
        {
            throw new Exception("Файл містить більше одного рядка з даними");
        }

        var parts = lines[0].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length != 2)
        {
            throw new Exception("Рядок має містити два числа, розділені пробілом");
        }

        if (!int.TryParse(parts[0], out var sum))
        {
            throw new Exception("Перше число має бути цілим числом");
        }

        if (!int.TryParse(parts[1], out var digitsCount))
        {
            throw new Exception("Друге число має бути цілим числом");
        }

        return (sum, digitsCount);
    }

    public static void WriteResultToFile(string max, string min)
    {
        File.WriteAllText(OutputFileName, $"{max} {min}");
    }
}
