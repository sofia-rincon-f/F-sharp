Orden estudio: 
        1. Tuplas
        2. Listas (modulos)
        3. Opcionales 
            -> Uniones discriminadas (modulos)
        4. Records (modulos)
        5. Array (Arreglos modulos)

Elementos esenciales:
            a. Ejercicio de calcular impuestos
            b. Refactoring
            c. Seq (función perezosa)
            d. Maping (Transformación)
            e. Juego de cartas
            f. Elecciones

Tuplas: 
    let tupla = (1, "hola") //Creación

    let primero = fst tupla // acceso a tupla de dos elementos
    let segundo  = snd tupla 
    printfn $"Primero elemento: {primero} \nSegundo elemento: {segundo}"

    //


    let tupla2 = (1, "hola", "marcos") //Creación

    let (numero, saludo, nombre) = tupla2 // acceso a tupla de más de dos elementos

    printfn $"{numero}"

    // Nota: Las tuplas tambien se identifican así: elemento1 * elemento2 en casos de Union discriminada. 
    //Para let puede escribirse sin parentesis 

Listas:
    List.forAll // Verifica si todos los elementos de la lista cumplen una condición.

    List fold   // Acumula un valor aplicando una función a cada elemento de la lista.

    List.find   // Busca el primer elemento que cumple una condición.
    List.tryFind // Busca un elemento que cumple una condición y devuelve una opción.

    List.head // Retorna el primer elemento de la lista.
    List.tail // Retorna todos los elementos menos el primero.

    List.length  // Retorna la longitud de la lista.

    List.sort // Ordena la lista.
    List.sortBy // Ordena la lista según una función.

    List.skip // Salta los primeros n elementos de la lista.

    List.groupBy // Agrupa los elementos de la lista según una función.

    List.map // Aplica una función a cada elemento de la lista y devuelve una nueva lista.
    List.filter // Filtra los elementos de la lista según una condición.
    List.iter // Aplica una función a cada elemento de la lista sin devolver nada.

Optionals y Uniones Discriminadas:
    
    Las uniones discriminadas son tipos de casos. 
    Cada caso puede contener datos adicionales.
    
    Ejemplo Union discriminada:
        type Colores =
        | Blanco
        | Rojo
        | Negro //Casos simple
        | RGB of int * int * int // caso con constantes (Tupla de tres enteros)
        | RGBA of float * float * float * float

        //Valores
        let color1 = Blanco
        let color2 = RGB(255, 0, 0)
        let color3 = RGBA(0.5, 0.5, 0.5, 1.0)

        //Patron de coincidencia
        let describirColor color =
            match color with
            | Blanco -> "Es blanco"
            | Rojo -> "Es rojo"
            | Negro -> "Es negro"
            | RGB(r, g, b) -> 
                $"RGB con valores: {r}, {g}, {b}"
            | RGBA(r, g, b, a) -> 
                $"RGBA con valores: {r}, {g}, {b}, {a}"    
    
    Ejemplo de opcional:
        type Option<'T> =
        | Some of 'T
        | None

        //Crear un valor opcional
        let valor1 = Some(42)
        let valor2 = None

        //Patron de coindicencia 
        let procesarOpcion opcion =
        match opcion with
        | Some(valor) -> $"El valor es {valor}"
        | None -> "No hay valor"

        Modulos de Option
            Map:
            let opcion = Some(10)
            let resultado = opcion |> Option.map (fun x -> x * 2) // Resultado: Some(20)

Records:
    
    Ejemplo 
    type Persona = // Propiedades
        { Nombre: string
        Edad: int }   

    let persona1 = { Nombre = "Juan"; Edad = 30 } // Creación

    printfn $"Nombre: {persona1.Nombre}, Edad: {persona1.Edad}" //Acceso a las propiedades

    let persona2 = { persona1 with Edad = 35 } // Copia y modifica una propiedad

Array (Arreglos):

    1. Creación de Arrays

        let arreglo1 = [| 1; 2; 3 |] // Arreglo de enteros
        let arreglo2 = [| "Hola"; "Mundo" |] // Arreglo de cadenas
        let arreglo3 = [| 1; "Hola"; 3.14 |] // Arreglo de diferentes tipos

        //Crear un array con un rango
        let arreglo4 = [| 1 .. 10 |] // Arreglo de enteros del 1 al 10

        //Crear un array inicializado con una funcion:
        let arreglo5 = Array.init 5 (fun i -> i * 2) // Arreglo de enteros: [| 0; 2; 4; 6; 8 |]

    2. Acceso a Elementos

        let arreglo = [| 1; 2; 3; 4; 5 |]

        //Acceso a un elemento por indice
        let elemento = arreglo.[0] // Acceso al primer elemento

        //Modificar un elemento (Los arreglos son mutables)
        arreglo.[0] <- 10 // Cambia el primer elemento a 10
        
    3. Operaciones con Arrays
        Array.length // Retorna la longitud del arreglo
        Array.map // Aplica una función a cada elemento del arreglo y devuelve un nuevo arreglo.
        Array.filter // Filtra los elementos del arreglo según una condición.
        Array.fold // Acumula un valor aplicando una función a cada elemento del arreglo.
        Array.iter // Aplica una función a cada elemento del arreglo sin devolver nada.
        Array.sort // Ordena el arreglo.
        Array.concat // Concatena varios arreglos en uno solo.

    4. Ejemplo entero
    
        let array = [| 1; 2; 3; 4; 5 |]

        // Transformaciones
        let arrayDoble = Array.map (fun x -> x * 2) array
        let arrayPares = Array.filter (fun x -> x % 2 = 0) array

        // Reducción
        let suma = Array.fold (+) 0 array

        // Búsqueda
        let primeroMayorQueTres = Array.find (fun x -> x > 3) array

        // Ordenación
        let arrayOrdenado = Array.sort array

        // Concatenación
        let nuevoArray = Array.append array [| 6; 7 |]

        printfn $"Array original: {array}"
        printfn $"Array doble: {arrayDoble}"
        printfn $"Array pares: {arrayPares}"
        printfn $"Suma: {suma}"
        printfn $"Primero mayor que tres: {primeroMayorQueTres}"
        printfn $"Array ordenado: {arrayOrdenado}"
        printfn $"Nuevo array: {nuevoArray}"



//──────────────────────── ୨୧ ──────────────────────────

Dian ejemplo Records

    1. En este ejemplo, iniciamos declarando una variable, llamada 

Eleciones 
Intro (Busqueda de paises) Listas modulos
Map ejemplo
Ejemplo paises 
    //Con listas de tuplas
    //Con listas de records
Monedas
Record avanzado
Cartas Uniones discriminadas

