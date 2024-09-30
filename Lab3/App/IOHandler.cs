namespace App;

public static class IOHandler
{
    private const string InputFileName = "INPUT.TXT";
    private const string OutputFileName = "OUTPUT.TXT";

    public static string ReadPathFromFile()
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

        if (lines.Length != 1)
        {
            throw new InputException("Файл містить більше одного рядка з даними");
        }

        return lines[0].Trim();
    }

    public static void WriteResultToFile(string path)
    {
        File.WriteAllText(OutputFileName, path);
    }
}
