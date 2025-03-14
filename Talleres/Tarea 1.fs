Usando el modulo de listas crear una función

let l = [1;2;3;4;5;6;7;8;9;10] 

Reserch (función muy específica con el módulo de listas) 

let s = cuadrado l

 s= [1;4;9;16;25;36;49;64;81;100] 

Iterar sobre s e imprimir en una línea 1491625
(Que si cambia los valores de let L se cambien los cuadrados) 



//Taller resuelto


//Según Microsoft Learn, se puede crear una secuencia que 
//potencie al cuadrado, el intervalo de los numeros que yo defina

let l = [for i in 1..10 -> i*i]

l 
|> List.iter (fun (l)-> printfn$"{l}")


// Tambien está el elemento .map, que itera la lista y aplica 
//una funcion a cada elemento, creando otra lista nueva

let lista2 = [1;2;3;4;5;6;7;8;9;10]

let funcionpotencia = lista2 |> List.map (fun x -> x*x)

funcionpotencia |> List.iter (fun e -> printfn $"{e}")

printf $"{funcionpotencia}"
