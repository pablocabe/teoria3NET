using System;

Console.WriteLine("Ingrese un numero de ejercicio");
string? input = Console.ReadLine();
int ejercicio = int.Parse(input ?? "0");
switch (ejercicio){
    case 1:
        ejercicio1();
        break; 
    case 2:
        ejercicio2();
        break;
}

/* Ejercicio 1
Ejecutar y analizar cuidadosamente el siguiente programa
Comprobar tipeando teclas y modificadores (shift, ctrl, alt) para apreciar de qué manera se 
puede acceder a esta información en el código del programa.
*/

static void ejercicio1(){
    Console.CursorVisible = false;
    ConsoleKeyInfo k = Console.ReadKey(true);
    while (k.Key != ConsoleKey.End){
    Console.Clear();
    Console.Write($"{k.Modifiers}-{k.Key}-{k.KeyChar}");
    k = Console.ReadKey(true);
    }
}

/* Ejercicio 2
Implementar un método para imprimir por consola todos los elementos de una matriz (arreglo de dos 
dimensiones) pasada como parámetro. Debe imprimir todos los elementos de una fila en la misma línea 
en la consola.
Ayuda: Si A es un arreglo, A.GetLength(i) devuelve la longitud del arreglo en la dimensión i.
*/

static void ejercicio2(){
    void ImprimirMatriz(double[,] matriz);
}