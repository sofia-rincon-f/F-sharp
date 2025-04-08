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

let Lista1 = ["Hola";"Mundo";"Feliz"]

Lista1 
|> List.iter (fun elemento -> printfn $"{elemento}")    // List.iter itera la lista, no imprime nada 


let head = Lista1 |> List.head                          // List.head busca el primer elemento de la lista 

printfn $"cabeza: {head}"

let buscarPorPrimeraLetra letra =
    Lista1 
    |> List.tryFind (fun elemento -> letra = elemento[0])   // List.tryFind busca un elemento 


match 
    buscarPorPrimeraLetra 'F'
with 
    | Some (value) -> printfn $"Encontr: {value}"
    | None -> printfn "No se encontro nada"


let test =
    unaLista 
    |> List.forall (fun elemento -> elemento % 2 <> 0 )   // List.forall aplica una condiccin boleana y todos deben cumplir la condicion 

printfn $"{test}"






                                                            
                                                            
                                                            
let test1 = 
    unaLista 
    |> List.sort                    // List.sort organiza una lista de elemntos basicos, faciles de comparar 

    |> List.rev                     // List.rev pone la lista alreves 

printfn $"{test1}"







type Directorio = {
    Nombre: string
    Cedula: int 
}

let lista2 = [
    {Nombre = "Leo"; Cedula = 9}
    {Nombre = "Dharen" ; Cedula = 10}
    {Nombre = "Sofia" ; Cedula = 8}
    {Nombre = "Stefany" ; Cedula = 7}
]

let test3 =
    lista2 
    |>List.sortBy (fun elemento -> elemento.Nombre) //List.sortBy organiza lista de elementos mas complejos (listas,tuplas,records)
    |>List.map (fun elemento -> elemento.Cedula)    //List.map transforma la lista en otra cumpliendo la condicion que le pogamos 

printfn $"{test3}"




type Portafolio = {
    Banco: string
    Saldo: decimal                            // decimal es otro tipo de notacion, se escribe con m, es más preciso
}                                             // La naturaleza usa más valores naturales, que no son exactos

let Lista4 = [
    {Banco = "Bancolombia"; Saldo = 1234.45m}
    {Banco = "ScotiaBank"; Saldo = 5000.6m}
    {Banco = "Davivienda"; Saldo = 50009.67m}
]                                      

let test4 =
    Lista4
    |>List.fold (fun acumulador elemento -> elemento.Saldo + acumulador) 10m  //List.fold tiene una funcion de un elemento y un acumulador. despues le doy el valor de inicio 

printfn $"{test4}"


// Fibonacci series
// 0 1 1 2 3 5 8 13 21 34 55

let generarFibonaci n =

    let (_,_,serie)=
        [2..n]                          // No hace nada pero llama la función fold
        |> List.fold 
            (fun (a,b,lista) _-> 
                let c =a+b
                (b,c, c :: lista)) (0,1,[])
    serie |> List.rev

let result = generarFibonaci 20

printfn $"{result}"


// Factorial 
// n! = 1*2*3...*n


let factorial n = 
    [1..n]
    |> List.fold (fun producto elemento -> elemento*producto) 1

let factor = factorial 10 
printf $"{factor}"


// reversar lista 

let reversarLita lista =
    lista
    |> List.fold (fun resultado elemento -> elemento :: resultado) []


let reversa = ["Hola"; "Mundo"; "Feliz"] |> reversarLita

printfn $"{reversa}"

// fold es bueno para totalizar

let consolidar lista =
    let head = lista |> List.head
    lista 
    |> List.skip 1
    |> List.fold (fun acc e -> acc+","+e) head


let constest = consolidar ["Y"; "me"; "faltas"; "al"; "respeto"]

printfn $"{constest}"

// Formato .CSV (coma separated value)