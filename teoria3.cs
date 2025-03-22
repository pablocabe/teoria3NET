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
    case 3:
        ejercicio3();
        break;
}

/* Ejercicio 1
Ejecutar y analizar cuidadosamente el siguiente programa
Comprobar tipeando teclas y modificadores (shift, ctrl, alt) para apreciar de qué manera se 
puede acceder a esta información en el código del programa.
*/

void ejercicio1(){
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

 void ejercicio2(){
    int[,] matriz = new int[,]{{1,2,3},{4,5,6}};
    imprimirMatriz(matriz);
}

 void imprimirMatriz (int[,] matriz){
    for (int i = 0; i < matriz.GetLength(0); i++){
        Console.Write(matriz[i,0]);
    }

    Console.WriteLine(matriz.GetLength(0)); // imprime cantidad de filas
    Console.WriteLine(matriz.GetLength(1)); // imprime cantidad de columnas
}

/* Ejercicio 3
Implementar el método ImprimirMatrizConFormato, similar al anterior pero ahora con un
parámetro más que representa la plantilla de formato que debe aplicarse a los números al imprimirse.
La plantilla de formato es un string de acuerdo a las convenciones de formato compuesto, por ejemplo
“0.0” implica escribir los valores reales con un dígito para la parte decimal
*/

void ejercicio3(){
    double[,] matriz = new double[,]{{1.1,2.2,3.3},{4.4,5.5,6.6}};
    ImprimirMatrizConFormato(matriz, "0.0");
}

void ImprimirMatrizConFormato(double[,] matriz, string formatString){
    for (int i = 0 ; i < matriz.GetLength(0) ; i++){
        for (int j = 0 ; j < matriz.GetLength(1) ; j++){
            Console.WriteLine(matriz[i,j].ToString(formatString));
        }
    }
}

/* Ejericio 4
Implementar los métodos GetDiagonalPrincipal y GetDiagonalSecundaria que devuelven
un vector con la diagonal correspondiente de la matriz pasada como parámetro. Si la matriz no es
cuadrada generar una excepción ArgumentException
*/

void ejercicio4(){
    
}
