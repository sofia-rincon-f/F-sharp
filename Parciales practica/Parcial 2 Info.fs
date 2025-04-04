// Union discriminada

type Colores = 
    | Blanco
    | Rojo
    | Negro
    | RGB of int*int*int
    | HSV of int*int*int
    | RGBA of float*float*float*float

type Tipos = 
    | Blanco 
    | Criculo 
    | Tripode 

let miColor= Colores.Blanco
let otroColor = RGBA(1.0, 1.0, 1.0, 0.6)


// 😼 Los Maps ni  Sets son ordenados. Solo Array y Listas

// 🤠 cabeza primer elemento Cola el resto de la lista



let unaLista = [10;2;3]                         // heas es 10 y tail es 2;3
let otraLista = [2]                             // head es 2 y tail es []

let unaListaCons = 10 :: [2;3]
let otraListaCons = 2 :: []                     //Cons Parcial 

match unaLista with 
    | x :: y  -> printfn $"{x} -> {y}"
    | [] -> printfn "Lista Vacia"


let listaNueva = otraLista @ unaLista               // que la primera lista sea más pequeña que la segunda
                                                    // que ambas listas sean del mismo elemento
printfn $"{listaNueva}"


// List module 

// List.iter = Recorre, más no retorna nada
// List.head = Retorna la cabeza de la lista 
// List.find = busca un elemento en la lista PERO explota si no lo encuentra
// List.tryFind = retorna una opcion del valor Some(value) si lo encuentra None si no lo encuentra