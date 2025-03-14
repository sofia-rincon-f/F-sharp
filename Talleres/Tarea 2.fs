- Encontrar una función que me diga si un número es primo o no (función booleana)
- Los numeros se manejaran en enteros
- Retorne true if n es primo
- Pista:
    
    let n1=11
    
    let listaDinamica = [2..(n1-1)]
    
    let esPrimo n1 =

//Tarea Numeros Primos
let numeros = [1..100]

let esPrimo n =
    let divisores = [2..(n-1)] |> List.filter (fun e -> n % e = 0)
    divisores.Length = 0


let confirmarprimos n1 = 
    if esPrimo n1 then
        printf $"{n1} es primo"
    else
        printf $"{n1} no es primo" 

let result n1 = 
    confirmarprimos n1

let n1 = 8
result n1