let numeros = [1..10]

let ordenar lista =
    lista
    |> List.sortByDescending (fun e -> e)  // Ordena de mayor a menor
    |> List.map (fun n -> n) 

let result = ordenar numeros

printfn $"{result}" 



let sumayresta lista = 
    lista
    |> List.sum |> (fun e -> (e/2))


let resultado = sumayresta numeros 

printf $"{resultado}"


let nombres = ["Sofi"; "Marialex"; "Michelin"; "Juanito"; "Selena"; "Ema"; 
            "Carlitos"; "Reina"; "Finn"; "Norma"]

let ordenasnombre lista =
    lista
    |> List.sort

let result2 = ordenasnombre nombres

printfn $"{result2}"


let tuplas = [
    ("Carlo", 45)
    ("Sam", 12)
    ("Jeremiah", 10)
    ("Hortensia", 46)
    ("Amparo", 34)
    ("Josue", 27)
    ("Emiro", 8)
]


let mayores = tuplas |> List.sortBy (fun(_,edad)-> -edad) |> List.map (fun (nombres,_)-> nombres)

let menores = tuplas |> List.sortBy (fun(_,edad)-> edad) |> List.map (fun (nombres,_)-> nombres)

printfn $"Lista ordenada de menores es {menores}"
printfn $"Lista ordenada de mayores es {mayores}"