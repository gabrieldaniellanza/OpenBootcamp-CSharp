// Operadores Determina los operadores para verificar las siguientes condiciones:

// Un número es mayor o igual a 18
int numero = 10;
bool esMayor = numero >= 18;

// Un char es ‘a’
char caracter = 'v';
bool es_a = caracter.Equals('a');

// Se cumplen dos conciones a la vez (ambas verdaderas)
bool dos_condiciones_verdaderas = (numero == 10 && es_a.Equals('v'));

// Se cumple una de dos condiciones a la vez (una true y otra false)
bool una_condicion_es_verdadera = (numero == 10 || es_a.Equals('v'));
