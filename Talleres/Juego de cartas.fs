//
// A game of cards
//

open System

let rnd = new Random() // This is a seed

let lanzarDado() =
    rnd.Next(1,7)

let lanzarDados() =
    lanzarDado(),lanzarDado()

// [1..10]
// |> Seq.iter ( fun _ -> printfn $"{lanzarDado()}")

let generarNumeroUnico low high set =
    let rec chequearNumero n =
        if not (set |> Set.contains n) then
            n
        else
            chequearNumero (rnd.Next(low,high+1))

    chequearNumero (rnd.Next(low,high+1))

let generarNumeroUnicoNuevo low high set =
    Seq.initInfinite (fun _ -> rnd.Next(low,high))
    |> Seq.pick (fun x -> if set |> Set.contains x then None else Some x)

let generarMuestra n low high =

    [1..n]
    |> Seq.fold ( fun set _ -> 
                    let r = generarNumeroUnicoNuevo low high set
                    set |> Set.add r
    ) Set.empty


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

let baraja = [|
    for pinta in [Corazones; Diamantes; Picas; Treboles] do
        As pinta
        Jack pinta
        Reina pinta
        Rey pinta
        for i in [2..10] do CartaNumero(i,pinta)
    
|]


let generarMano2() =
    generarMuestra 5 0 51
    

let r = generarMano2()

r
|> Seq.iter (fun i -> printfn $"{baraja[i]}")

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
            | [(_,[_]);(_,[_;_]);(_,[_;_])] -> TwoPairs
            | [(_,[_]);(_,[_]);(_,[_;_;_])] -> ThreeOfAKind
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

let testMano = 
    r
    |> Seq.map (fun i -> baraja[i])
    |> Seq.toList 
    |> evaluarMano

printfn $"Valor de la mano: {testMano}"





// Generar una mano para un jugador
let generarMano() =
    generarMuestra 5 0 51
    |> Seq.map (fun i -> baraja[i])
    |> Seq.toList

// Generar manos para varios jugadores
let generarManos jugadores =
    jugadores
    |> List.map (fun jugador -> (jugador, generarMano()))

// Evaluar y mostrar las manos de los jugadores
let evaluarManos jugadores =
    let manos = generarManos jugadores
    manos
    |> List.iter (fun (jugador, cartas) ->
        let tipoMano = evaluarMano cartas
        printfn $"{jugador} tiene {cartas} y su mano es {tipoMano}")
    manos // Retornar las manos para determinar el ganador

// Determinar el ganador
let determinarGanador manos =
    manos
    |> List.map (fun (jugador, cartas) -> (jugador, cartas, evaluarMano cartas)) // Evaluar la mano de cada jugador
    |> List.maxBy (fun (_, _, mano) -> mano) // Seleccionar la mano más alta

// Función principal para simular el juego
let jugarCartas () =
    let jugadores = ["Jugador 1"; "Jugador 2"; "Jugador 3"; "Jugador 4"]
    let manos = evaluarManos jugadores
    let ganador = determinarGanador manos

    // Mostrar el ganador
    match ganador with
    | (jugador, _, mano) ->
        printfn $"El ganador es {jugador} con la mano {mano}"

// Ejecutar el juego
jugarCartas()