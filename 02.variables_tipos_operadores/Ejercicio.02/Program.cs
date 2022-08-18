
string? ingreso;

Console.WriteLine("COCHE:");
    
Console.WriteLine("Ingrese la cantidad de puertas:");
int puertas = int.Parse(Console.ReadLine());

Console.WriteLine("Ingrese la cantidad de ruedas:");
int ruedas = int.Parse(Console.ReadLine());

Console.WriteLine("Ingrese la marca:");
string? marca = Console.ReadLine();
    
Console.WriteLine("Ingrese si tiene IVT vigente [S/N]:");
bool IVT_vigente = Console.ReadLine().ToUpper().Equals("S");


Console.WriteLine(Environment.NewLine + Environment.NewLine);

Console.WriteLine("MESA");

Console.WriteLine("Ingrese el peso:");
decimal peso = decimal.Parse(Console.ReadLine());

Console.WriteLine("Ingrese largo:");
decimal largo = decimal.Parse(Console.ReadLine());

Console.WriteLine("Ingrese el material:");
string? material = Console.ReadLine();

Console.WriteLine("Ingrese color:");
string? color = Console.ReadLine();
