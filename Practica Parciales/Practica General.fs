Orden estudio: 
        1. Tuplas
        2. Listas (modulos)
        3. Opcionales 
            -> Uniones discriminadas (modulos)
        4. Records (modulos)
        5. Array (Arreglos modulos)

Elementos esenciales:
            a. Ejercicio de la DIAN
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

DIAN Ejemplo de una lista de Records:

    //
    // Convertir de UVT a pesos
    //

    let uvtFactor = 47065.0
    let uvtToPesos x =
        x*uvtFactor
    let pesosToUvt x =
        x/uvtFactor

    type TaxBrackets =
        {
            RangoBajo: float
            RangoAlto: float
            Impuesto: float
            Base: float
        }

    let dianTable =
        [
            {
                RangoBajo = 0.0
                RangoAlto = 1090.0
                Impuesto = 0.0
                Base = 0.0
            }
            {
                RangoBajo = 1090.0
                RangoAlto = 1700.0
                Impuesto = 0.19
                Base = 0.0
            }
            {
                RangoBajo = 1700.0
                RangoAlto = 4100.0
                Impuesto = 0.28
                Base = 116.0
            }
            {
                RangoBajo = 4100.0
                RangoAlto = 8670.0
                Impuesto = 0.33
                Base = 788.0
            }
            {
                RangoBajo = 8670.0
                RangoAlto = 18970.0
                Impuesto = 0.35
                Base = 2296.0
            }
            {
                RangoBajo = 18970.0
                RangoAlto = 31000.0
                Impuesto = 0.37
                Base = 5901.0
            }
            {
                RangoBajo = 31000.0
                RangoAlto = 999999.0
                Impuesto = 0.39
                Base = 10352.0
            }

        ]

    //
    // Esta funcion busca en la tabla, comparando
    // la uvt con el RangoBajo y el RangoAlto
    //
    let findTaxBracket uvt =
        dianTable
        |> List.find 
            (fun bracket 
                ->
                uvt >= bracket.RangoBajo && uvt < bracket.RangoAlto
            )


    let calculateTax uvt bracket =
        (uvt-bracket.RangoBajo)*bracket.Impuesto+bracket.Base

    let calcularImpuesto uvt =
        uvt
        |> findTaxBracket
        |> calculateTax uvt
    let salario = 30000000.0*12.0


    let tax =
        salario
        |> pesosToUvt
        |> calcularImpuesto
        |> uvtToPesos

    printfn $"Total a pagar {tax}"

//──────────────────────── ୨୧ ──────────────────────────
Refactoring:
    // Antes: Código imperativo
    let sumaListaImperativa lista =
        let mutable suma = 0
        for elemento in lista do
            suma <- suma + elemento
        suma

    // Después: Código funcional
    let sumaListaFuncional lista =
        List.fold (+) 0 lista

//──────────────────────── ୨୧ ──────────────────────────
Secuencias:
    // Ejemplo de secuencias (Seq)

    let numeros = seq { 1 .. 10 } // Secuencia de números del 1 al 10

    // Secuencia infinita de números pares
    let pares = Seq.initInfinite (fun i -> i * 2)

    // Tomar los primeros 10 números pares
    let primerosDiezPares = pares |> Seq.take 10 |> Seq.toList

    // Filtrar números mayores a 5
    let mayoresA5 = numeros |> Seq.filter (fun x -> x > 5)

    // Mapear para duplicar los valores
    let duplicados = numeros |> Seq.map (fun x -> x * 2)

    // Imprimir resultados
    printfn $"Números: {numeros |> Seq.toList}"
    printfn $"Primeros 10 pares: {primerosDiezPares}"
    printfn $"Mayores a 5: {mayoresA5 |> Seq.toList}"
    printfn $"Duplicados: {duplicados |> Seq.toList}"

//──────────────────────── ୨୧ ──────────────────────────
Maping:
    // Ejemplo de mapeo (Mapping)

    let numeros = [1; 2; 3; 4; 5]

    // Mapear para duplicar los valores
    let duplicados = List.map (fun x -> x * 2) numeros

    // Mapear para convertir números a cadenas
    let comoCadenas = List.map string numeros

    // Imprimir resultados
    printfn $"Números originales: {numeros}"
    printfn $"Números duplicados: {duplicados}"
    printfn $"Números como cadenas: {comoCadenas}"

    Cartas Uniones discriminadas

    //
    // A game of cards
    //

    //
    // Este es un discriminated union
    //
    type Pinta =
        | Corazones
        | Diamantes
        | Picas
        | Treboles

    type CartaDeJuego =
        | As of Pinta
        | Rey of Pinta
        | Reina of Pinta
        | Jack of Pinta
        | CartaNumero of int * Pinta // Esta es una tupla

    //
    // Helper functions for the big homework
    //

    //
    // Esta funcion nos retorna la pinta de cuaquier carta
    //

    let obtenerPintaDeCarta carta =
        match carta with 
        | As pinta -> pinta
        | Rey pinta -> pinta
        | Reina pinta -> pinta
        | Jack pinta -> pinta
        | CartaNumero(_,pinta) -> pinta

    let result = obtenerPintaDeCarta (CartaNumero(10,Corazones))
    printfn $"La pinta de la carta es: {result}"

    //
    // Funcion que chequea si una lista de cartas es de la misma
    // pinta
    //
    let mismaPintaEnLista listaCartas =
        //
        // La pinta de muestra la sacamos del primer elemento de la lista
        //
        let pintaMuestra = listaCartas|> List.head |> obtenerPintaDeCarta

        //
        // Usamos forall para comprobar 
        listaCartas
        |> List.forall(fun e -> obtenerPintaDeCarta(e) = pintaMuestra)

    let test = mismaPintaEnLista [As(Treboles);CartaNumero(10,Corazones);Rey(Treboles);CartaNumero(3,Corazones)]
    printfn $"Misma pinta es {test}"

    //
    // Obtener valor de la carta, esto es util para
    // ordernar la mano
    //
    let obtenerValorDeCarta carta =
        match carta with
        | CartaNumero(x,_) -> x
        | Jack(_) -> 11
        | Reina(_) -> 12
        | Rey(_) -> 13
        | As(_)-> 14


    //
    // Esta funcion da un valor arbitrario a cada suit
    //

    let obtenerValorDePinta carta =
        match carta |> obtenerPintaDeCarta with
        | Treboles -> 1
        | Picas -> 2
        | Corazones -> 3
        | Diamantes -> 4

    //
    // Esta funcion compara dos cartas usando el standard
    // de la funcion compare (-1,0,1)
    //
    // Esta funcion compara el suit primero, y luego el 
    // valor de la carta
    //
    let compararCartas carta1 carta2 =
        let pinta1 = carta1 |> obtenerValorDePinta
        let pinta2 = carta2 |> obtenerValorDePinta
    
        let c1 = compare pinta1 pinta2
        if c1 <> 0 
            then
                c1
            else
                let valor1 = carta1 |> obtenerValorDeCarta
                let valor2 = carta2 |> obtenerValorDeCarta
                compare valor1 valor2


    //
    // Ordenar las cartas es muy facil ahora, solo tenemos
    // que usar nuestra funcion de comparación
    //

    let ordenarMano cartas =
        cartas
        |> List.sortWith compararCartas

    let test2 = ordenarMano [As(Treboles);CartaNumero(10,Corazones);Rey(Treboles);CartaNumero(3,Corazones)]

    printfn "Mano ordernada"
    test2 |> List.iter (fun e -> printfn $"{e}")

    //
    // Necesitamos una funcion que  nos diga
    // si una lista de cartas esta en secuencia.
    // Se asume que la lista esta ordenada.
    //
    let esUnaSecuencia cartas =
        cartas
        // Solo nos interesa el valor de la carta
        |> Seq.map obtenerValorDeCarta
        //Pairwise retorna una tupla de dos elementos
        |> Seq.pairwise
        // Con los pares calculamos la diferencia 
        |> Seq.map (fun (e1,e2) -> e2 - e1)
        // Chequeamos que todos sean 1
        |> Seq.forall (fun e -> e = 1)

    let manoEjemplo = 
        [
            CartaNumero(8,Corazones)
            CartaNumero(8,Treboles)
            CartaNumero(8,Diamantes)
            CartaNumero(9,Picas) 
            CartaNumero(9,Diamantes)
        ]
    let testSecuencia = 
        manoEjemplo
        |> ordenarMano
        |> esUnaSecuencia

    printfn $"Resultado de secuencia: {testSecuencia}"


    //
    // Esta union de Mano, nos da el tipo y el valor
    // a la vez (es el orden de la declaracion)
    type Mano =
        | Nada
        | Pair
        | TwoPairs
        | ThreeOfAKind
        | Straight
        | Flush
        | FullHouse 
        | FourOfAKind
        | StraightFlush
        | RoyalFlush


    //
    // Esta funcion busca un tipo basico de mano
    // las cartas deben ir en orden y tener la misma
    // pinta
    let encontrarTipoDeFlush cartas =
        //
        // Miremos si hay una sequencia
        //
        if cartas |> esUnaSecuencia then
            match cartas |> List.head with
            | CartaNumero(10,_) -> RoyalFlush
            | _ -> StraightFlush
        else
            Flush


    let testFlush = manoEjemplo |> ordenarMano |> encontrarTipoDeFlush
    printfn $"Tipo de flush: {testFlush}"

    //
    // Esta funcion busca un Full House, y four of a kind.
    // Esta funcion requiere que las cartas esten en orden.
    //
    let encontrarOtrasManos cartas =
        if cartas |> esUnaSecuencia then
                Straight
            else
                // Buscamos dos combinaciones, una de 3 y 2
                // Y otrade 4 iguales.
                match cartas 
                    |> List.groupBy obtenerValorDeCarta
                    |> List.sortBy (fun (_,e) -> e |> List.length) 
                with
                | [(_,[_]);(_,[_]);(_,[_]);(_,[_;_])] -> Pair
                | [(_,[_;_]);(_,[_;_;_])] -> FullHouse
                | [(_,[_]);(_,[_;_;_;_])] -> FourOfAKind
                | _ -> Nada

    //
    // Implementacion parcial de evaluar mano.
    // Esta es la funcion principal de la tarea,
    // ya cubrimos 3 de los 5 casos con los Flush
    // Solo queda implementar el resto.
    //

    let evaluarMano cartas =
        let cartasOrdenadas = cartas |> ordenarMano
        match cartasOrdenadas |> mismaPintaEnLista with
        | true -> cartasOrdenadas |> encontrarTipoDeFlush
        | false -> cartasOrdenadas |> encontrarOtrasManos

    let testMano = manoEjemplo |> evaluarMano
    printfn $"Valor de la mano: {testMano}"

//──────────────────────── ୨୧ ──────────────────────────
Eleciones:
    type Candidato =
        {
            Cedula: int
            Nombre: string
            Partido: string
        }

    type EstadoVoto =
        | Marcado
        | EnBlanco

    type Tarjeton =
        {
            EstadoUno: EstadoVoto
            EstadoDos: EstadoVoto
            EstadoTres: EstadoVoto
        }

    let candidatos =
        [
            {Cedula = 101; Nombre = "JFK"; Partido ="Democrata"}
            {Cedula = 273; Nombre = "Guillermo Leon Valencia"; Partido="Liberal"}
            {Cedula = 564; Nombre = "Ronald Reagan";Partido ="Republicano"}
        ]

    let resultados =
        [
            {EstadoUno = Marcado;EstadoDos=EnBlanco;EstadoTres=EnBlanco}
            {EstadoUno = Marcado;EstadoDos=Marcado;EstadoTres=EnBlanco}
            {EstadoUno = EnBlanco;EstadoDos=EnBlanco;EstadoTres=EnBlanco}
            {EstadoUno = EnBlanco;EstadoDos=EnBlanco;EstadoTres=EnBlanco}
            {EstadoUno = EnBlanco;EstadoDos=Marcado;EstadoTres=EnBlanco}
            {EstadoUno = Marcado;EstadoDos=EnBlanco;EstadoTres=EnBlanco}
            {EstadoUno = Marcado;EstadoDos=EnBlanco;EstadoTres=EnBlanco}
            {EstadoUno = Marcado;EstadoDos=EnBlanco;EstadoTres=EnBlanco}
            {EstadoUno = EnBlanco;EstadoDos=Marcado;EstadoTres=EnBlanco}
            {EstadoUno = EnBlanco;EstadoDos=EnBlanco;EstadoTres=Marcado}
            {EstadoUno = EnBlanco;EstadoDos=EnBlanco;EstadoTres=Marcado}
            {EstadoUno = EnBlanco;EstadoDos=EnBlanco;EstadoTres=Marcado}
            {EstadoUno = EnBlanco;EstadoDos=EnBlanco;EstadoTres=Marcado}
            {EstadoUno = EnBlanco;EstadoDos=Marcado;EstadoTres=EnBlanco}
            {EstadoUno = EnBlanco;EstadoDos=Marcado;EstadoTres=EnBlanco}
            {EstadoUno = EnBlanco;EstadoDos=EnBlanco;EstadoTres=Marcado}
        ]

    type Resultado =
        | CandidatoUno
        | CandidatoDos
        | CandidatoTres
        | Invalido
        | Blanco

    let mapaCandidato = [(CandidatoUno,273);(CandidatoDos,564);(CandidatoTres,101)] |> Map.ofList

    let resultadosIniciales =
        [
            CandidatoUno,0
            CandidatoDos,0
            CandidatoTres,0
            Invalido,0
            Blanco,0
        ]
        |> Map.ofList

    let incrementarVoto acumulador (key:Resultado) =
        let total = acumulador |> Map.find key
        acumulador |> Map.add key (total+1)

    let procesarVoto acumulador voto =
        let incremente = incrementarVoto acumulador

        match voto.EstadoUno,voto.EstadoDos,voto.EstadoTres with
        | EnBlanco,EnBlanco,EnBlanco -> incremente Blanco
        | Marcado, EnBlanco,EnBlanco -> incremente CandidatoUno
        | EnBlanco,Marcado,EnBlanco -> incremente CandidatoDos
        | EnBlanco,EnBlanco,Marcado -> incremente CandidatoTres
        | _ -> incremente Invalido

    let totalizarVotos votos =
        votos
        |> List.fold procesarVoto resultadosIniciales

    let encontrarInformacionCandidato key =
        mapaCandidato 
        |> Map.find key
        |> fun cedula ->
            candidatos |> List.find (fun r -> r.Cedula = cedula)
        

    let convertirANombreYVotos (key,votos) =
    match key with
            | Blanco -> "En Blanco",votos
            | Invalido -> "Voto Invalido",votos
            | _ -> 
                    let info = encontrarInformacionCandidato key
                    info.Nombre+" ** "+info.Partido,votos 

    resultados
    |> totalizarVotos
    |> Map.toArray
    |> Array.sortByDescending (fun (_,votos) -> votos)
    |> Array.map convertirANombreYVotos
    |> Array.iter (fun (nombre,votos) -> printfn $"{nombre} -> {votos}" )

//──────────────────────── ୨୧ ──────────────────────────
Ejemplo paises 
   
    //Con listas de tuplas
        let numeros = [5.001; 4.998; 5.002; 4.998]

        let sumLista lista = 
            lista 
            |> List.fold (fun acc e -> acc+e) 0.0 

        //
        // Sigmasquare without let
        //
        let sigmaSquare (lista: float list) =
            lista
            |> sumLista
            |> fun e -> e/float lista.Length
            |> fun mean ->
                lista 
                |> List.map (fun e -> (e-mean)*(e-mean))
            |> sumLista
            |> fun e -> e/float lista.Length

            
        let sigma = numeros |> sigmaSquare |> sqrt
        printfn $"Standard Deviation is {sigma}"




        // Taller calificable

        //Punto 1 Agregar población

        let atlas =
            [ ("Colombia", "Bogota", 52320000)
            ("Francia", "Paris", 68290000)
            ("España", "Madrid", 48350000)
            ("Azerbaiyán", "Baku", 10150000)
            ("Alemania", "Berlin", 83280000) 
            ("Japon","Tokyo", 124500000)
            ]


        // Punto 2 BuscarCapital con tryFind

        let buscarCapital pais =
            atlas 
            |> List.tryFind (fun (p,_,_) -> p = pais)
            |> Option.map (fun (_,c,_) -> c)



        let pais = "Japon"
        match pais |> buscarCapital with
        | Some nombre -> printfn $"{nombre}"
        | None -> printfn "No existe ese pais"



        //Punto 3 Buscar número de haitantes

        let buscarHabitantes pais2 =  
            match atlas |> List.tryFind (fun (p,_,_) -> p = pais2) with
            | Some ((_,_,h)) -> h
            | None -> 
                printfn $"No se encontro número de habitantes"
                0


        let pais2 = "Japon"
        let result2 = buscarHabitantes pais2

        printfn $"El numerro de habitantes de {pais2} es {result2}"

        // Punto 4 Odernar paises por tamaño de población 



        let obtenerlista () =
            atlas
            |> List.sortBy (fun (_,_,habitantes) -> habitantes)
            |> List.map (fun (pais,_,_) -> pais)

        let imprimir = obtenerlista ()

        printfn $"{imprimir}"


        // Punto 5 Imprimir paises dentro de un limite establecido de habitantes

        let limite lim =
            atlas 
            |> List.filter (fun (_,_,habitantes) -> (habitantes >= lim))
            |> List.map (fun (pais,_,_) -> pais)

        let imprimirlimite = limite 50000000

        printfn $"{imprimirlimite}"
    //──────────────────────── ୨୧ ──────────────────────────
    //Con listas de records
        type Atlas = {
            Pais: string
            Capital: string
            Habitantes: int
            Pib: float //field
        }

        let atlas =
            [ 
                {
                    Pais = "Colombia"
                    Capital = "Bogota"
                    Habitantes = 52320000
                    Pib = 363.5
                }
                {
                    Pais = "Francia" 
                    Capital = "Paris"
                    Habitantes = 68290000
                    Pib = 3052.0
                }
                {
                    Pais = "España" 
                    Capital = "Madrid" 
                    Habitantes = 48350000
                    Pib = 1620.0
                }
                {
                    Pais = "Azerbaiyán" 
                    Capital = "Baku"
                    Habitantes = 10150000
                    Pib = 72.36
                }
                {
                    Pais = "Alemania" 
                    Capital = "Berlin"; 
                    Habitantes = 83280000
                    Pib = 4520.0
                }
                {
                    Pais = "Japon"; 
                    Capital = "Tokyo"; 
                    Habitantes = 124500000
                    Pib = 4204.0
                }
            ]

        let elemento = atlas[1]
        let nuevoPais = { elemento with Habitantes = 78290000; Pib =8000.0}
        printfn $"El pais es: {nuevoPais.Pais} {nuevoPais.Habitantes}"

        let buscarCapital pais =
            match atlas |> List.tryFind (fun r -> r.Pais = pais) with
            | Some(r) -> r.Capital
            | None ->
                printfn $"Capital No encontrada!"
                ""


        let pais = "Alemania"
        let result = buscarCapital pais

        printfn $"La capital de {pais} es {result}"


        //Punto 3 Buscar número de haitantes

        let buscarHabitantes pais =  
            match atlas |> List.tryFind (fun r -> r.Pais = pais) with
            | Some (r) -> r.Habitantes
            | None -> 
                printfn $"No se encontro número de habitantes"
                0


        let pais2 = "Japon"
        let result2 = buscarHabitantes pais2

        printfn $"El numerro de habitantes de {pais2} es {result2}"

        // Punto 4 Odernar paises por tamaño de población 



        let obtenerlista () =
            atlas
            |> List.sortBy (fun r -> r.Habitantes)
            |> List.map (fun r -> r.Pais)

        let imprimir = obtenerlista ()

        printfn $"{imprimir}"


        // Punto 5 Imprimir paises dentro de un limite establecido de habitantes

        let limite lim =
            atlas 
            |> List.filter (fun r -> (r.Habitantes >= lim))
            |> List.map (fun r -> r.Pais)

        let imprimirlimite = limite 50000000

        printfn $"{imprimirlimite}"

        let ordenarPorPib () =
            atlas
            |> List.sortBy (fun r -> r.Pib)
            |> List.map (fun r -> r.Pais)
            |> List.rev

        let bigCountries = ordenarPorPib ()
        printfn $"{bigCountries}"
