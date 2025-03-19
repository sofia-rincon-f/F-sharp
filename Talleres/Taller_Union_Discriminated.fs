Realizar un ejercicio donde 
1. Le pase una mano de 5 cartas a una función match 
2. La función me retorne (desde Flush hasta Royal Flush) que valor asignado (del 1 al 5) tiene mi carta


// A game of cards
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
    | Sota of Pinta
    | CartaNumero of int * Pinta 


let imprimirPinta carta  =
    match carta with
    | Corazones -> printfn "La Pinta es Corazones"
    | Diamantes -> printfn "La Pinta es Diamantes"
    | _ -> printfn "Aun no se que pinta es"
