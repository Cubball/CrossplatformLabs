﻿using ClassLib;
using McMaster.Extensions.CommandLineUtils;

const string DefaultInputFileName = "INPUT.TXT";
const string DefaultOutputFileName = "OUTPUT.TXT";

var app = new CommandLineApplication
{
    Name = "R_Davydchuk",
    Description = "Crossplatform lab work 4",
};

app.HelpOption();

app.Command("version", versionCmd =>
{
    versionCmd.Description = "Show version";
    versionCmd.OnExecute(() =>
    {
        Console.WriteLine("Author: Roman Davydchuk, IPZ-31");
        Console.WriteLine("Version: 1.0.0");
    });
});

app.Command("set-path", setPath =>
{
    setPath.Description = "Set path to folder with input and output files";
    var path = setPath.Option("-p|--path", "Path to folder", CommandOptionType.SingleValue).IsRequired();
    setPath.OnExecute(() =>
    {
        if (OperatingSystem.IsWindows())
        {
            Environment.SetEnvironmentVariable("LAB_PATH", path.Value(), EnvironmentVariableTarget.User);
        }
        else
        {
            Environment.SetEnvironmentVariable("LAB_PATH", path.Value());
        }
    });
});

app.Command("run", run =>
{
    run.Description = "Run lab";
    run.OnExecute(() =>
    {
        Console.WriteLine("Specify the lab to run");
        run.ShowHelp();
        return 1;
    });

    var input = run.Option("-i|--input", "Input file path", CommandOptionType.SingleValue);
    var output = run.Option("-o|--output", "Output file path", CommandOptionType.SingleValue);

    run.Command("lab1", lab1 =>
    {
        lab1.Description = "Run lab 1";
        var folderPath = Environment.GetEnvironmentVariable("LAB_PATH");
        if (string.IsNullOrWhiteSpace(folderPath))
        {
            folderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        }

        var inputFilePath = input.HasValue() ? input.Value() : Path.Combine(folderPath, DefaultInputFileName);
        var outputFilePath = output.HasValue() ? output.Value() : Path.Combine(folderPath, DefaultOutputFileName);

        lab1.OnExecute(() =>
        {
            FirstLab.Execute(inputFilePath ?? "", outputFilePath ?? "");
            return 0;
        });
    });

    run.Command("lab2", lab2 =>
    {
        lab2.Description = "Run lab 2";
        var folderPath = Environment.GetEnvironmentVariable("LAB_PATH");
        if (string.IsNullOrWhiteSpace(folderPath))
        {
            folderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        }

        var inputFilePath = input.HasValue() ? input.Value() : Path.Combine(folderPath, DefaultInputFileName);
        var outputFilePath = output.HasValue() ? output.Value() : Path.Combine(folderPath, DefaultOutputFileName);

        lab2.OnExecute(() =>
        {
            SecondLab.Execute(inputFilePath ?? "", outputFilePath ?? "");
            return 0;
        });
    });

    run.Command("lab3", lab3 =>
    {
        lab3.Description = "Run lab 3";
        var folderPath = Environment.GetEnvironmentVariable("LAB_PATH");
        if (string.IsNullOrWhiteSpace(folderPath))
        {
            folderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        }

        var inputFilePath = input.HasValue() ? input.Value() : Path.Combine(folderPath, DefaultInputFileName);
        var outputFilePath = output.HasValue() ? output.Value() : Path.Combine(folderPath, DefaultOutputFileName);

        lab3.OnExecute(() =>
        {
            ThirdLab.Execute(inputFilePath ?? "", outputFilePath ?? "");
            return 0;
        });
    });

});

app.OnExecute(() =>
{
    Console.WriteLine("Specify a subcommand");
    app.ShowHelp();
    return 1;
});

try
{
    return app.Execute(args);
}
catch (Exception e)
{
    Console.WriteLine($"An error occurred: {e.Message}");
    return 1;
}
