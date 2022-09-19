// See https://aka.ms/new-console-template for more information

DateTime FirstDayOfYear = new DateTime(2022, 1, 1);

Console.WriteLine( Math.Ceiling((DateTime.Now - FirstDayOfYear).TotalDays));
