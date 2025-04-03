// Union discriminada. Obligatori que los elementos esten en mayuscula

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

let listaUno = ["Hola"; "Mundo";"nuevo"]


listaUno
|> List.iter (fun elemento -> printfn $"{elemento}") //unit

let head = listaUno |> List.head

printfn $"Cabeza: {head}"

let buscarPorprimeraLetra letra =
    listaUno
    |> List.tryFind (fun elemento -> letra = elemento[0])

match 
    buscarPorprimeraLetra 'n' // char
with 
    | Some(value) ->printfn $"Encontré {value}"
    | None -> printfn "No se encontró nada"

// List.forall aplica una función booleana a cada elemento y retorna verdadero si la función es verdadera para TODOS los elementos

let listaNumeros = [1..2..20]

let test =
    listaNumeros
    |> List.forall (fun e -> e % 2 = 0) // FALSO

let test2 =
    listaNumeros
    |> List.forall (fun a -> a % 2 <> 0) // VERDADERO

printfn $"{test}"
printfn $"{test2}"


// List.sort Organiza elementos basicos faciles de comparar (int, string, floats)

// List.sortBy organiza elementos más completos (Listas, records, tuplas)
// List.filter parcial 
// List.rev reversa la lista

let sortLista = [3;4;7;9;10;2;1]

let testsort =
    sortLista
    |> List.sort
    |> List.rev

printfn $"{testsort}"

// Practicar organizar bien la lista de bancos alfabeticamente 

// TRANSFORMACIONES


// Tomar una lista y convertirla: en escalar o vectorial (Las listas son vectores)


// List.map de una lista a otra (de vector a vector)

// List.fold toma un vector y lo vuelve escalar (una lista de varios elementos que retona un solo elemento)


// Ejemplo desde sortBy

type RecordsSort = {
        Nombre : string
        Cedula: int
}


let ListaRecords = [
    {Nombre = "Leo"; Cedula = 10}
    {Nombre = "UTP"; Cedula = 1}
]

let testRecord =
    ListaRecords
    |> List.sortBy (fun elemento -> elemento.Cedula) // Ordena por cedula

let Map = 
    ListaRecords
    |> List.map ( fun elemento -> elemento.Nombre) // Hara una lista de salida solo de nombres


printfn $"{testRecord}"

printfn $"{Map}"

let numeros = [1..10]


let Map2 = 
    numeros
    |> List.map ( fun elemento -> elemento*4+5) // Operacion matematica



//Fold 

type Portafolio = {
        Banco: string
        Saldo: decimal // En programas financieros es necesario usar decimal. Caben casi todos los numeros
}


let ListaFold = [
    {Banco = "Bancolombia"; Saldo = 1234.45m} // m letra de decimal
    {Banco = "Nu"; Saldo = 5000.6m}
    {Banco = "Falabella"; Saldo = 50009.67m}
]


let fold = 
    ListaFold
    |> List.fold ( fun acumulador elemento -> elemento.Saldo+acumulador) 0m // el 0 es el "pasado" de mi acumulador. Aquí sumaremos todo nuestro saldo
    // List.map (fun e ->e.Saldo)
    // List.sum  //Solución alterna.
printf $"{fold}"


// Factoriales Parcial

