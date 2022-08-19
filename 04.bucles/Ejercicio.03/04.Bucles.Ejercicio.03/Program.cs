/* 
 
 Escribe un programa que realice estos pasos:

Reciba 3 datos:
ancho
alto
relleno o no

Dibuje en consola con un mismo caracter, por ejemplo *, 
un rectángulo de las dimensiones introducidas 
y use el tercer dato para discernir si el rectángulo está relleno (tiene más * dentro) o no.

En caso de recibir el mismo número n dos veces debe dibujar un cuadrado de lado n.
Reto: Extiende el programa anterior para recibir otro número que sea el número 
de cuadrados o rectángulos que se deben dibujar en la pantalla. Ejemplos:

Input: 2,2,2, relleno = true
Output:
** **
** **
Input: 3, 4, 1, relleno = false
Output:
***
* *
* *
***

 */


int ancho =0;
int alto = 0;
int cuadrados = 1;
bool relleno = false;
int parseado = 0;

Console.WriteLine("Ingrese ancho:");
string? ingreso = Console.ReadLine();
if (ingreso != null && int.TryParse(ingreso, out parseado) && parseado > 0)
    ancho = parseado;

Console.WriteLine("Ingrese alto:");
ingreso = Console.ReadLine();
if (ingreso != null && int.TryParse(ingreso, out parseado) && parseado > 0)
    alto = parseado;

Console.WriteLine("Ingrese cantidad de cuadrados:");
ingreso = Console.ReadLine();
if (ingreso != null && int.TryParse(ingreso, out parseado) && parseado > 0)
    cuadrados = parseado;

Console.WriteLine("¿Relleno? [S/N]:");
ingreso = Console.ReadLine();
if (ingreso != null && ingreso.ToUpper().Equals("S"))
    relleno = ingreso.ToUpper().Equals("S");

for(int al = 1; al <= alto; al++)
{
    for(int cu = 1; cu <= cuadrados; cu++)
    {
        for (int an = 1; an <= ancho; an++)
        {
            if (al == 1 || al == alto || an == 1 || an == ancho)
                Console.Write("*");
            else if (relleno)
                Console.Write("*");
            else
                Console.Write(" ");
        }

        Console.Write(" ");
    }

    Console.WriteLine();
}