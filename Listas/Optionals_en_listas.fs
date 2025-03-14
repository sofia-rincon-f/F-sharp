// Pares e impares List.tryFind

let value1 = Some(3)

let value2 = None 

let exampleFunction value =
    match value with 
    | Some(x) -> printfn $"El valor es {x}"
    | None -> printfn "No hay valor"
    
exampleFunction value1
exampleFunction value2


// List.try vs List.tryFind

let nuevalistapaises = [("japon", "tokyo"); ("colombia", "bogota"); ("argentina", "buenos aires"); ("Mexico", "CDMX")]


// Genera excepción
let buscarCapital pais = 
    let (_, capital) = 
        nuevalistapaises
        |> List.find (fun (p,_) -> p=pais)
    capital 

//Retorna sin excepción
let buscaraCapital2 pais = 
    match nuevalistapaises |> List.tryFind (fun (p,_) -> p =pais) with
    | Some((_, b)) -> b 
    | None ->
        printfn $"Capital No encontrada"
		
                
let pais = "Japon"
let result = buscarCapital pais