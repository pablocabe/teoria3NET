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
    case 4:
        ejercicio4();
        break;
    case 5:
        ejercicio5();
        break;
    case 6:
        ejercicio6();
        break;
    case 7:
        ejercicio7();
        break;
    case 8:
        ejercicio7();
        break;
}

/* Ejercicio 1
Ejecutar y analizar cuidadosamente el siguiente programa
Comprobar tipeando teclas y modificadores (shift, ctrl, alt) para apreciar de qué manera se 
puede acceder a esta información en el código del programa.
*/

void ejercicio1(){
    Console.CursorVisible = false;
    // la propiedad Console.CursorVisible controla la visibilidad del cursor en la consola.
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
    double[,] matriz = new double[,]{{1, 2, 3},{4, 5, 6}};
    imprimirMatriz(matriz);
}

 void imprimirMatriz (double[,] matriz){ // Recorre las filas
    for (int i = 0 ; i < matriz.GetLength(0) ; i++){ // Recorre las columnas
        for (int j = 0 ; j < matriz.GetLength(1) ; j++){
            Console.Write(matriz[i,j] + " "); // Imprime elemento con espacio
        }
        Console.WriteLine(); // Salto de línea al finalizar una fila
    }
    Console.ReadKey(true);

    // Console.WriteLine(matriz.GetLength(0)); devuelve cantidad de filas
    // Console.WriteLine(matriz.GetLength(1)); devuelve cantidad de columnas
}

/* Ejercicio 3
Implementar el método ImprimirMatrizConFormato, similar al anterior pero ahora con un
parámetro más que representa la plantilla de formato que debe aplicarse a los números al imprimirse.
La plantilla de formato es un string de acuerdo a las convenciones de formato compuesto, por ejemplo
“0.0” implica escribir los valores reales con un dígito para la parte decimal
*/

void ejercicio3(){
    double[,] matriz = new double[,]{{1.1, 2.2, 3.3},{4.4, 5.5, 6.6}};
    ImprimirMatrizConFormato(matriz, "0.0");
}

void ImprimirMatrizConFormato(double[,] matriz, string formatString){
    for (int i = 0 ; i < matriz.GetLength(0) ; i++){ // Recorre las columnas
        for (int j = 0 ; j < matriz.GetLength(1) ; j++){
            Console.Write(matriz[i,j].ToString(formatString) + " "); // Imprime elemento con espacio
        }
        Console.WriteLine(); // Salto de línea al finalizar una fila
    }
    Console.ReadKey(true);
}

/* Ejericio 4
Implementar los métodos GetDiagonalPrincipal y GetDiagonalSecundaria que devuelven
un vector con la diagonal correspondiente de la matriz pasada como parámetro. Si la matriz no es
cuadrada generar una excepción ArgumentException
*/

void ejercicio4(){

    int[,] matriz = new int[,]{
    {1, 2, 3},  // 1ª fila con 3 columnas
    {4, 5, 6},  // 2ª fila con 3 columnas
    {7, 8, 9},  // 3ª fila con 3 columnas
    {10, 11, 12}};  // 4ª fila con 3 columnas (4 filas en total)

    try
    {
        int[] diagonalPrincipal = GetDiagonalPrincipal(matriz);
        int[] diagonalSecundaria = GetDiagonalSecundaria(matriz);

        Console.WriteLine("Diagonal Principal: " + string.Join(", ", diagonalPrincipal));
        Console.WriteLine("Diagonal Secundaria: " + string.Join(", ", diagonalSecundaria));
    }

    catch (ArgumentException e)
    {
        Console.WriteLine("Error: " + e.Message);
    }

    finally
    {
        Console.WriteLine("Ingrese un caracter para finalizar el programa");
        Console.ReadKey(true);
    }
}

int[] GetDiagonalPrincipal (int[,] matriz){

    int filas = matriz.GetLength(0);
    int columnas = matriz.GetLength(1);

    if (filas != columnas){
        throw new ArgumentException("La matriz no es cuadrada");
    }

    int[] diagonal = new int[filas];

    for (int i = 0 ; i < filas ; i++){
        diagonal[i] = matriz[i,i];
    }

    return diagonal;
}

int[] GetDiagonalSecundaria (int[,] matriz){

    int filas = matriz.GetLength(0);
    int columnas = matriz.GetLength(1);

    if (filas != columnas){
        throw new ArgumentException("La matriz no es cuadrada");
    }

    int[] diagonal = new int[filas];

    for (int i = 0 ; i < filas ; i++){
        diagonal[i] = matriz[i, columnas - 1 - i];
    }

    return diagonal;
}

/*Ejercicio 5
Implementar un método que devuelva un arreglo de arreglos con
los mismos elementos que la matriz pasada como parámetro:
double[][] GetArregloDeArreglo(double [,] matriz)
*/

void ejercicio5(){
    
    double[,] matriz = new double[,]{
        {1, 2, 3},  // 1ª fila con 3 columnas
        {4, 5, 6},  // 2ª fila con 3 columnas
        {7, 8, 9}};  // 3ª fila con 3 columnas
    
    double[][] ArregloDeArreglos = GetArregloDeArreglos(matriz);

    for (int i = 0; i < ArregloDeArreglos.Length; i++){
        Console.WriteLine(string.Join(", ", ArregloDeArreglos[i]));
    }
    Console.WriteLine("Ingrese un caracter para finalizar el programa");
    Console.ReadKey(true);
}


double[][] GetArregloDeArreglos(double[,] matriz){

    int filas = matriz.GetLength(0);
    int columnas = matriz.GetLength(1);

    double[][] ArregloDeArreglos = new double[filas][]; // solo se define el tamaño de la primera dimensión

    for (int i = 0; i < matriz.GetLength(0); i++){
        ArregloDeArreglos[i] = new double[columnas]; // inicializar cada fila individualmente
        for (int j = 0; j < matriz.GetLength(1); j++){
            ArregloDeArreglos[i][j] = matriz[i, j];
        }
    }

    return ArregloDeArreglos;
}


/* Ejercicio 6
Implementar los siguientes métodos que devuelvan la suma, resta y multiplicación de matrices 
pasadas como parámetros. Para el caso de la suma y la resta, las matrices deben ser del mismo tamaño, 
en caso de no serlo devolver null. Para el caso de la multiplicación la cantidad de columnas de A debe 
ser igual a la cantidad de filas de B, en caso contrario generar una excepción ArgumentException.

double[,]? Suma(double[,] A, double[,] B)
double[,]? Resta(double[,] A, double[,] B)
double[,] Multiplicacion(double[,] A, double[,] B)
*/

void ejercicio6(){

}

/* Ejercicio 7
¿De qué tipo quedan definidas las variables x, y, z en el siguiente código? 
*/

void ejercicio7(){
    int i = 10;
    var x = i * 1.0;
    var y = 1f;
    var z = i * y;
}

/* Ejercicio 8
Señalar errores de compilación y/o ejecución en el siguiente código
*/

void ejercicio8(){
    object obj = new int[10];
    dynamic dyna = 13;
    Console.WriteLine(obj.Length);
    Console.WriteLine(dyna.Length); 
}