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
    | CartaNumero of int * Pinta 

let pintaUno = Diamantes
let cartaUno = CartaNumero(8, Treboles)

let hand = [As(Corazones); Rey(Picas); CartaNumero(4, Diamantes)]

//
// Funcion donde retorno la pinta de la carta dada
//

let obtenerPinta carta =
    match carta with 
    | As(pinta) -> pinta
    | Rey(pinta) -> pinta
    | Reina(pinta) -> pinta
    | Jack(pinta) -> pinta
    | CartaNumero (_, pinta) -> pinta


let Test = obtenerPinta (Jack(Treboles))


printfn $"{Test}"

//
// Funcion donde corroboro que una lista de cartas tienen la misma pinta
//

let mismaPintaMano mano = 
    let pintaReferencia = mano |> List.head |> obtenerPinta
    mano
    |> List.forall (fun e -> obtenerPinta e = pintaReferencia)

let testDos = mismaPintaMano [As(Corazones); Rey(Corazones); CartaNumero(4, Corazones)]
    
printfn $"{testDos}"


// Asignar un valor numerico a las cartas altas a partir del Jack. Retornar el valor numerico de una carta dada

let valorNumerico carta = 
    match carta with 
    | As(_) -> 14
    | Rey(_) -> 13
    | Reina(_) -> 12
    | Jack(_) -> 11
    | CartaNumero (n, _) -> n


let TestTres = valorNumerico (CartaNumero(8, Treboles))


printfn $"{TestTres}"



// Asignar valor a la pinta

let obtenervalorPinta carta = 
    let pinta = carta |> obtenerPinta
    match pinta with 
    | Treboles -> 1
    | Picas -> 2
    | Corazones -> 3
    | Diamantes -> 4


let testcuatro = obtenervalorPinta (Rey(Treboles))


// Comparar números 

let comparacionCartas carta1 carta2 =
    let pinta1 = carta1 |> obtenervalorPinta
    let pinta2 = carta2 |> obtenervalorPinta
    
    let c = compare pinta1 pinta2

    if c <> 0 
        then 
            c 
        else 
            let valor1 = carta1 |> obtenervalorPinta
            let valor2 = carta2 |> obtenervalorPinta
            compare valor1 valor2

let testcinco = comparacionCartas (As(Treboles)) (As(Corazones))

printfn $"{testcinco}"


let ordenar mano =
    mano
    |> List.sortWith (fun carta1 carta2 ->
        let pinta1 = obtenervalorPinta carta1
        let pinta2 = obtenervalorPinta carta2
        
        let resultadoPinta = compare pinta1 pinta2
        if resultadoPinta <> 0 then 
            resultadoPinta
        else 
            let valor1 = valorNumerico carta1
            let valor2 = valorNumerico carta2
            compare valor1 valor2
    )