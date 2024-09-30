using System.Text;
using App;

Console.OutputEncoding = Encoding.Unicode;

string path;
try
{
    path = IOHandler.ReadPathFromFile();
}
catch (Exception e)
{
    Console.WriteLine($"Під час зчитування файлу виникла помилка: {e.Message}");
    return;
}

string pathBack;
try
{
    pathBack = PathFinder.FindPathBack(path);
}
catch (Exception e)
{
    Console.WriteLine($"Під час знаходження розв'язку виникла помилка: {e.Message}");
    return;
}

try
{
    IOHandler.WriteResultToFile(pathBack);
}
catch (Exception e)
{
    Console.WriteLine($"Під час запису файлу виникла помилка: {e.Message}");
}
