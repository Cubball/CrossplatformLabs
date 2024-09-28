using System.Globalization;

namespace App;

public static class IOHandler
{
    private const string InputFileName = "INPUT.TXT";
    private const string OutputFileName = "OUTPUT.TXT";

    public static (int Count, List<int> Numbers) ReadNumbersFromFile()
    {
        if (!File.Exists(InputFileName))
        {
            throw new InputException($"Файл {InputFileName} не було знайдено.");
        }

        var lines = File.ReadAllLines(InputFileName)
            .Select(static line => line.Trim())
            .Where(static line => !string.IsNullOrWhiteSpace(line))
            .ToArray();
        if (lines.Length == 0)
        {
            throw new InputException("Файл не містить жодного тексту");
        }

        if (lines.Length != 2)
        {
            throw new InputException("Файл містить більше двох рядків з даними");
        }

        if (!int.TryParse(lines[0].Trim(), out var count))
        {
            throw new InputException("Перше число має бути цілим числом");
        }

        var parts = lines[1]
            .Trim()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var nums = new List<int>();
        foreach (var part in parts)
        {
            if (!int.TryParse(part, out var num))
            {
                throw new InputException("Другий рядок має містити тільки цілі числа, розділені пробілами");
            }

            nums.Add(num);
        }

        return (count, nums);
    }

    public static void WriteResultToFile(int num)
    {
        File.WriteAllText(OutputFileName, num.ToString(CultureInfo.InvariantCulture));
    }
}
