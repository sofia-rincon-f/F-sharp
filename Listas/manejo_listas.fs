//Lista
let atlas  = [    
    ("colombia", " bogota");   
	("Francia", " Paris");   
	("España", " Madrid");    
	("Azerbaiyán", " Bakú");   
    ("Alemania", " Belin")    
	("Japon", " Tokyo")
    ]

//Función iterar e imprimir solo el pais
let imprimirpais lista =     
	lista |> List.iter (fun (pais,_) -> printfn $"{pais}")

//Función iterar e imprimir solo la capital
let imprimircapital lista =    
	lista |> List.iter (fun (_,capital)-> printfn $"{capital}")

//Función iterar e imprime el mensaje completo
let mensaje lista =     
	lista |> List.iter (fun (pais, capital) -> printfn $"La capital de {pais} es{capital}")

atlas |> mensaje // es lo mismo que escribir mensaje atlas, imprimirpais atlas, imprimircapital atlas

//Organiza por pais
atlas 
|> List.sortBy (fun (pais, _) -> pais)
|> imprimirpais

//Organiza por capital
atlas 
|> List.sortBy (fun (_, capital) -> capital)
|> imprimircapital

//iter no retorna y map retorna 
let listapaises =    atlas |> List.map (fun (pais,_) -> pais)
let listacapitales =    atlas |> List.map (fun (_,capital) -> capital)


printfn $"{listapaises}"
printfn $"{listacapitales}"


// suma sencilla o el factorial de un número

let Numbers = [1..10] |> List.suma



