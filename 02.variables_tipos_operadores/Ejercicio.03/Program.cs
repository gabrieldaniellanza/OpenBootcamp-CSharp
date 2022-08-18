// Operadores Determina los operadores para verificar las siguientes condiciones:

// Un número es mayor o igual a 18
int numero = 10;
bool esMayor = numero >= 18;
Console.WriteLine("{0} es mayor o igual a 18: {1}", numero, esMayor);

// Un char es ‘a’
char caracter = 'v';
bool es_a = caracter.Equals('a');
Console.WriteLine("'{0}' es igual a 'a': {1}", caracter, es_a);

// Se cumplen dos conciones a la vez (ambas verdaderas)
bool dos_condiciones_verdaderas = (numero == 11 && caracter.Equals('v'));
Console.WriteLine("{0} es igual a 11 y '{1}' es igual a 'v': {2}", numero, caracter, dos_condiciones_verdaderas);

// Se cumple una de dos condiciones a la vez (una true y otra false)
bool una_condicion_es_verdadera = (numero == 11 || caracter.Equals('v'));
Console.WriteLine("{0} es igual a 11 o '{1}' es igual a 'v': {2}", numero, caracter, una_condicion_es_verdadera);


