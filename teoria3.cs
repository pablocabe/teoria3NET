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
        ejercicio8();
        break;
    case 9:
        ejercicio9();
        break;
    case 10:
        ejercicio10();
        break;
    case 11:
        ejercicio11();
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
    int i = 10; // integer
    var x = i * 1.0; // integer x double = double
    var y = 1f; // f = float
    var z = i * y; // integer x float = float

    Console.WriteLine(x.GetType());
    Console.WriteLine(y.GetType());
    Console.WriteLine(z.GetType());

    Console.WriteLine("Ingrese un caracter para finalizar el programa");
    Console.ReadKey(true);
}

/* Ejercicio 8
Señalar errores de compilación y/o ejecución en el siguiente código
*/

void ejercicio8(){
    object obj = new int[10]; // El objeto obj se declara como tipo object pero se inicializa con un arreglo de enteros
    dynamic dyna = 13;

    // Console.WriteLine(obj.Length); // El tipo object no tiene una propiedad Length, lo cual provoca un error de compilación
    // Para acceder a la longitud del arreglo, sería necesario hacer un casting explícito:
    // Console.WriteLine(((int[])obj).Length);

    Console.WriteLine(dyna.Length); // Dynamic permite evlauar en tiempo de ejecución pero el int 13 no tiene una propiedad Length
    // Para evitar el error, deberías verificar el tipo antes de intentar acceder a la propiedad
}


/* Ejercicio 9
¿Qué líneas del siguiente método provocan error de compilación y por qué?
*/

void ejercicio9(){
    // var a = 3L; // La letra L después del número entero indica que el valor es de tipo long en C#.
    dynamic b = 32; // b no tendrá comprobación en tiempo de compilación
    object obj = 3; // valor cuyo tipo puede variar en tiempo de ejecución

    // a = a * 2.0; // Error: long x double daría un double, y var representa inmutabilidad en el tipo de a
    // Como a es de tipo long, no puede almacenar el resultado, ya que el tipo no coincide.

    b = b * 2.0; // int x double = double. Ahora b, sin comprobación, se convierte en double
    b = "hola"; // ahora b es un string
    // No hay error de compilación porque el tipo de b se ajusta dinámicamente.

    obj = b; // obj almacena un string. No hay error porque ambos (dynamic y object) permiten almacenar cualquier tipo de valor.
    b = b + 11; // Esta instrucción provocará un error en tiempo de ejecución. No se puede sumar un string con un int.
    // obj = obj + 11; // Esta instrucción provoca un error en tiempo de compilación. El tipo object no admite directamente operaciones aritméticas.

    // Creación de objetos anónimos
    var c = new { Nombre = "Juan" };
    var d = new { Nombre = "María" };
    var e = new { Nombre = "Maria", Edad = 20 };
    var f = new { Edad = 20, Nombre = "Maria" };
    // f.Edad = 22; // Error: las propiedades de los objetos anónimos son inmutables. Sus propiedades son de solo lectura.
    d = c; // Pueden asignarse entre sí porque tienen exactamente el mismo tipo.
    // e = d; // Error: no pueden asignarse entre sí porque tienen distintos tipos.
    // f = e; // Error: aunque las propiedades son las mismas, el orden importa.
}

/* Ejercicio 10
Verificar con un par de ejemplos si la sección opcional [:formatString] de formatos 
compuestos redondea o trunca cuando se formatean números reales restringiendo la cantidad de 
decimales. Plantear los ejemplos con cadenas de formato compuesto y con cadenas interpoladas
*/

void ejercicio10(){

    double num1 = 3.14159;
    Console.WriteLine("{0:F2}", num1); // Dos decimales
    
    double num2 = 3.14159;
    Console.WriteLine($"{num2:F2}"); // Dos decimales

    // Ambas veces redondea de forma automática.
    // En el caso de números reales, la sección [:formatString] puede utilizarse para limitar la cantidad de decimales.
    // Sin embargo, el comportamiento por defecto es el redondeo, no la truncación, aunque puedes controlar esto con las especificaciones de formato.

}


/* Ejercicio 11
Señalar errores de ejecución en el siguiente código
*/

void ejercicio11(){
    
    List<int> a = [ 1, 2, 3, 4 ]; // Error en la sintaxis, está declarado pero no bien instanciado
    // List<int> a = new List<int> { 1, 2, 3, 4 };  // Forma correcta
    
    a.Remove(5); // No existe el elemento int 5, nunca lo encuentra
    a.RemoveAt(4); // Intenta eliminar el elemento en el índice especificado, pero está fuera de rango (0, 1, 2, 3)
}