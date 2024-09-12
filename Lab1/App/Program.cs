using App;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

var (sum, digitsCount) = IOHandler.ReadNumbersFromFile();
var max = NumberService.FindMaxForSumAndDigitsCount(sum, digitsCount);
var min = NumberService.FindMinForSumAndDigitsCount(sum, digitsCount);
IOHandler.WriteResultToFile(max, min);
