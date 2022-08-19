/*
 * Ejercicio 1 - While

Escribe una tabla de multiplicar del 1 al 10 para un número entero que recibe por consola. Es decir, un programa que presente para el 1:

1 x 1 = 1
1 x 2 = 2
…
1 x 10 = 10 */

Console.WriteLine("Ingrese el numero a multimplicar: ");
int producto1 = int.Parse(Console.ReadLine());

int producto2 = 0;
while (producto2 < 10)
{
    producto2++;
    Console.WriteLine($"{producto1} x {producto2} = {producto1 * producto2}");
};
