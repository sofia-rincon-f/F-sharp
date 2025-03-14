Reescribir la función sigmaSquare sin let (Con lambda y pipeline)


//Con let

let numeros = [5.001; 4.998; 5.002; 4.998]

let sumLista lista = 
    lista 
    |> List.fold (fun acc e -> acc+e) 0.0 

let sigmaSquare (lista: float list) =
    let n = lista.Length
    let mean = (sumLista lista)/(float n)
    let minSquare = 
        lista
        |> List.map (fun e -> (e-mean)*(e-mean))
    let variance = (sumLista minSquare)/(float n)
    variance

let sigma = sqrt(sigmaSquare numeros)

printfn $"La desviacion standar es {sigma}"

//Sin let

let numeros = [5.001; 4.998; 5.002; 4.998]

let sumLista lista = 
    lista 
    |> List.fold (fun acc e -> acc+e) 0.0 

let sigmaSquare (lista: float list) =
    let n = float lista.Length
    lista 
    |> List.fold (fun (acc, mean) e -> acc + (e - mean) * (e - mean), mean) (0.0, sumLista lista / n)
    |> fst
    |> (fun variance -> variance / n)

    
let sigma = sqrt

printfn $"La desviacion standar es {sigma}"

