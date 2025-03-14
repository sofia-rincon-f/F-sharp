//List.forall el cual retorna true si n es primo. 
//Tarea 2 de numeros primos resuelto.

let isprime n =
    match n with
    | 1 -> true  
    | 2 -> true 
    | 3 -> true 
    |_-> 
        let factors = [2..(n-1)]
        factors 
        |> List.forall (fun e -> n%e <> 0)

let result = isprime 1759 
printfn $"{result}"

//List.forall numeros pares

let numeros = [0..2..20]

let todosPares lista =
    lista
    |> List.forall (fun e -> e % 2 = 0)

let resultado = todosPares numeros

printfn $"{resultado}"

// List.fold esta funcion calcula la suma de todos los 
//elementos de la lista

let num =[1..50]

let sumList list = 
    list
    |> List.fold (fun acc e -> acc+e) 0

let suma = sumList num

printfn $"La suma es: {suma}"

//Otra manera de calcular factorial usando listas

let factorial n = 
    [1..n]
    |> List.fold (fun acc e -> e*acc) 1 

let n = 6 

let fact = n |> factorial
printfn $"El factorial de 6 es {fact}"

//Calcula la suma de todos los elementos 
//y sacar el promedio 

let datos = [0.78; 0.79; 0.67; 0.99; 0.81; 0.80; 0.81]

let sumLista lista = 
    lista 
    |> List.fold (fun acc e -> acc + e) 0.0

let suma = sumLista datos
let promedio = suma / (float datos.Length)

printfn $"El promedio es: {promedio}"