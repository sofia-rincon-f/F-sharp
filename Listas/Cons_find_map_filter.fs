//Agregar un lemento al final usando cons 
//(revierte del 10 al 3)

let numeros = [5..10]

let nuevaListas = 3 :: numeros

let agregarAlfinal n lista =     
    n :: lista |> List.rev

let lista2 = agregarAlfinal 3 numeros
printf$"{lista2}"


// Agregar un lemento al final usando cons 
//(Requiere dos reversas)

let numeros2 = [5..10]

let agregarAlfinal2 n lista =     
    let a = lista |> List.rev    
    n :: a |> List.rev
    
    
let lista3 = agregarAlfinal2 3 numeros2
printf$"{lista3}"

//Buscar el pais y retorna capittal
let atlas =    
   [("Colombia", "Bogota");    
   ("Francia", "Paris");    
   ("España", "Madrid");    
   ("Akerbaiyán", "Baku");    
   ("Alemania", "Berlin");    
   ("Japon", "Tokyo")    ]

let buscarcapital pais =    
     let (_,capital) = //Queremos el segundo parametro de la lista 
     atlas |> List.find (fun (p, _) -> p=pais)    
capital

let result = buscarcapital "Japon"
printf $"{result}"


// filtrar números pares
let numerosp = [1..20]

let filtreSoloPares lista =    
        lista |> List.filter (fun e -> (e % 2)=0)
        
let filtreSoloimpares lista =    
       lista |> List.filter (fun e -> (e % 2)<>0)
       
let pares = numerosp |> filtreSoloPares 

let impares = numerosp |> filtreSoloimpares

printfn $"{pares}"printfn $"{impares}"


// Usando List.map
let calcularCuadrados lista =    
     lista    
     |> List.map (fun e -> e*e)

let result2 = numeros |> calcularCuadrados

printfn $"{result2}"