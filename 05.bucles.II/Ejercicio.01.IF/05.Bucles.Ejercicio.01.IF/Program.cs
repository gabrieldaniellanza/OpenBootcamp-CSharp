/*
 Ejercicio 1 - If

Escribe un programa que:
Pida datos a un cliente: Nombre, email, cupón
Determine si un cliente tiene un cupon descuento
Muestre un precio rebajado en función del descuento
Muestre el precio de un producto sin descuento si no hay cupón
Nota: puedes poner un precio fijo de un producto o uno variable.
 * */

decimal precio = 100;

Dictionary<string, decimal> cupones = new Dictionary<string, decimal>();
cupones.Add("CUPON_DIEZ", (decimal)0.10);
cupones.Add("CUPON_AUTONOMO", (decimal)0.155);
cupones.Add("CUPON_VIP", (decimal) 0.204);


Console.WriteLine("Ingrese su nombre: ");
string? nombre = Console.ReadLine();

Console.WriteLine("Ingrese su e-mail: ");
string? email = Console.ReadLine();

Console.WriteLine("Ingrese su cupon: ");
string? cupon = Console.ReadLine();

decimal descuento = 0;
if (cupon != null && cupones.ContainsKey(cupon))
{
    cupones.TryGetValue(cupon, out descuento);
}

Console.WriteLine($"El producto le contará: $ {precio * (1 - descuento)}");
