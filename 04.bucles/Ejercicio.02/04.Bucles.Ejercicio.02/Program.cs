/* Escribe un programa que realice estos pasos:

Reciba al menos un número por consola

Determine si el número es positivo o negativo

Presente un contador para cada tipo (positivo y negativo).

Nota: el cero se puede abordar en una clase adicional ya que no es ni positivo ni negativo. Tienes completa libertad para elegir el formato de la salida.
*/

int positivos = 0;

int negativos = 0;

int numero = 1;
int parseado = 0;

do
{
    Console.WriteLine("Ingrese un numero: ");
    string? ingreso = Console.ReadLine();

    if (ingreso != null && int.TryParse(ingreso, out parseado)) { 
        numero = int.Parse(ingreso);

        if (numero < 0)
            negativos++;
        else if(numero > 0)
            positivos++;
    }

} while (numero != 0);

Console.WriteLine($"Ingresó {negativos} numeros negativos.");
Console.WriteLine($"Ingresó {positivos} numeros positivos.");