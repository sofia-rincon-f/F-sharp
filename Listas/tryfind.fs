let values = [1..3..20]

let pares = 
	values 
	|> List.tryFind (fun e -> e % 2 = 0)
	
	
match pares with 
| Some(values) -> printfn $"Encontre un par {value}"
| None -> printfn "No hay pares"
