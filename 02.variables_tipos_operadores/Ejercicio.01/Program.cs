
Console.WriteLine("Ingrese su nombre: ");
string? nombre = Console.ReadLine();

Console.WriteLine("Ingrese su apellido: ");
string? apellido = Console.ReadLine();

Console.WriteLine("Ingrese su edad: ");
int edad = int.Parse(Console.ReadLine());

Console.WriteLine("Sabe programar [S/N]: ");
bool sabeProgramar = Console.ReadLine().Equals("S");

string mensaje = "{0} {1}, ¡Que {2} que a tus {3} {4} sepas programar!";

Console.WriteLine(mensaje, nombre, apellido, (sabeProgramar ? "bueno" : "mal"), edad ,(sabeProgramar ? "ya" : "aun no"));