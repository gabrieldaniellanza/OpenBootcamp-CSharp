/* Ejercicio 2 - Switch

Haz una lista de lenguajes de programación, 
por ejemplo: C#, Java, C++. 
Presenta la lista en consola y pide que el usuario seleccione el lenguaje mediante 
1, 2, 3 o a, b, c. 
Presenta el resultado en consola.

Nota: puedes añadir al resultado el “Hola, mundo” para el caso de C#.
*/


List<string> ListaDeLenguajes = new List<string>() 
{
    "C#", "Java", "C++", "VB .net", "Python", "JavaScript"
};


Console.WriteLine("LENGUAJES:");

foreach ( string lenguaje in ListaDeLenguajes)
    Console.WriteLine($"{ListaDeLenguajes.IndexOf(lenguaje)+1} - {lenguaje}");

Console.WriteLine($"{Environment.NewLine}Selecciona un lenguaje:");
string? seleccion = Console.ReadLine();
int select;
string lenjuaje;

if (int.TryParse(seleccion, out select)) 
{
    // opcion sin switch
    //seleccion = $"Usted seleccionó : {ListaDeLenguajes[select - 1]}";

    // opcion con switch
    switch (select)
    {
        case 1:
            seleccion = $"Usted seleccionó : {ListaDeLenguajes[0]}";
            break;

        case 2:
            seleccion = $"Usted seleccionó : {ListaDeLenguajes[1]}";
            break;

        case 3:
            seleccion = $"Usted seleccionó : {ListaDeLenguajes[2]}";
            break;

        case 4:
            seleccion = $"Usted seleccionó : {ListaDeLenguajes[3]}";
            break;

        case 5:
            seleccion = $"Usted seleccionó : {ListaDeLenguajes[4]}";
            break;

        case 6:
            seleccion = $"Usted seleccionó : {ListaDeLenguajes[5]}";
            break;

        default:
            seleccion = "Opcion invalida";
            break;

    }

    Console.WriteLine(seleccion);
}




