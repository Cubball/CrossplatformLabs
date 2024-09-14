using System.Text;
using App;

Console.OutputEncoding = Encoding.Unicode;

int sum;
int digitsCount;
try
{
    (sum, digitsCount) = IOHandler.ReadNumbersFromFile();
}
catch (Exception e)
{
    Console.WriteLine($"Під час зчитування файлу виникла помилка: {e.Message}");
    return;
}

string max;
string min;
try
{
    max = NumberService.FindMaxForSumAndDigitsCount(sum, digitsCount);
    min = NumberService.FindMinForSumAndDigitsCount(sum, digitsCount);
}
catch (Exception e)
{
    Console.WriteLine($"Знаходження розв'язку виникла помилка: {e.Message}");
    return;
}

try
{
    IOHandler.WriteResultToFile(max, min);
}
catch (Exception e)
{
    Console.WriteLine($"Під час запису файлу виникла помилка: {e.Message}");
}
