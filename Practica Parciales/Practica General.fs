// Orden estudio 
        //1. Tuplas
        //2. Listas (modulos)
        //3. Opcionales -> Uniones discriminadas (modulos)
        //4. Records (modulos)
        //5. Array (Arreglos modulos)

//Elementos esenciales:
            //Ejercicio de calcular impuestos
            //Refactoring
            //Seq (función perezosa)
            //Maping (Transformación)
            //Juego de cartas
            //Elecciones


// Tuplas 
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

// Listas
    List.forAll  // Verifica si todos los elementos de la lista cumplen una condición.

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

// Dian ejemplo Records

    1. En este ejemplo, iniciamos declarando una variable, llamada 

//Eleciones 
//Intro (Busqueda de paises) Listas modulos
//Map ejemplo
//Ejemplo paises 
    //Con listas de tuplas
    //Con listas de records
//Monedas
//Record avanzado
//Cartas Uniones discriminadas

