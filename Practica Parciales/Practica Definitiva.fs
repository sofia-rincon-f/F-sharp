// Fibonacci serie forma 1

let fibonacci n = 

    let (_,_,s)=
        [2..n]
        |> List.fold
            (fun (a,b,lista)_->
                let c=a+b
                (b,c, c::lista)) (0,1,[1;0])
    s |> List.rev


let result = fibonacci 10

printfn $"{result}"


// Fibonacci serie forma 2

let fibonacci2 n =
    match n with 
    | 1 -> [0]
    | 2 -> [0;1]
    |_-> 
        [3..n]
        |> List.fold (fun (lista,a,b)_->(a+b :: lista, b, a+b))([1;0],0,1)
        |> fun(lista,_,_) -> lista
        |> List.rev

let f = fibonacci2 11
printfn $"{f}"

──────────────────────── ୨୧ ──────────────────────────

// Punto 1 .map  IMPARES

let generarImpares n = 
    [1..n]
    //|> List.map (fun n -> n%2 = 1 ) // imprime true n' false
    |> List.filter (fun n -> (n % 2)=1)


let imprimir = generarImpares 10


printfn $"{imprimir}"


──────────────────────── ୨୧ ──────────────────────────


// Punto 2 .map CUADRADOS

let listanumerica = [1;2;3;4;5]


let cuadrado lista = 
    lista 
    |> List.map (fun n -> n*n)

let prueba = cuadrado listanumerica


printfn $"{prueba}"

──────────────────────── ୨୧ ──────────────────────────


// Punto 3 .fold SUMA LISTA


let listadatos = [1;5;8;10;66;8]



let suma lista =
    lista 
    |> List.fold (fun e acc -> acc+e) 0


let prueba2 = suma listadatos 

printfn $"{prueba2}"

──────────────────────── ୨୧ ──────────────────────────


// 4 Record y sortBy EJEMPPLO DE PAISES

type Mapa = {
                    Pais: string
                    Capital: string
                    Habitantes: int
                    }

let mapa = [

        {
        Pais= "Colombia"
        Capital = "Bogota"
        Habitantes = 52
        }
        {
        Pais= "Argentina"
        Capital = "Buenos Aires"
        Habitantes = 45
        }
        {
        Pais= "Mexico"
        Capital = "Ciudad de Mexico"
        Habitantes = 129
        }
        {
        Pais= "Canada"
        Capital = "Ottawa"
        Habitantes = 40
        }
]


let ordenar ()=
    mapa 
    |> List.sortBy (fun r -> r.Habitantes)
    |> List.map (fun r -> (r.Pais, r.Habitantes)) //(fun e -> (r.Pais, r.Habitantes))
    |> List.rev


let Paises = ordenar ()
printf $"{Paises}"


// 5 Fold

let sumHabitantes() =
    mapa 
    |> List.fold (fun acc r -> acc+r.Habitantes) 0

let Totalsum = sumHabitantes()

printf $"{Totalsum}"


// 6 tryFind


//Forma compleja 

let buscarporPais pais =
        match mapa |> List.tryFind (fun r -> r.Pais = pais) with 
        | Some (r)-> Some r.Capital 
        | None -> None 

let buscar = buscarporPais "Colombia"
printfn $"{buscar}"


// Forma alternativa MODULO OPCIONES

let buscarporPais2 pais =
    mapa
    |> List.tryFind (fun e -> e.Pais = pais)
    |> Option.map (fun e -> e.Capital)


// 7 Usar opciones

let imprimirCapital pais = 
    match buscarporPais2 pais with
    | Some capital -> printfn $"La capital es {capital}"
    | None -> printfn $"Pais no existe"


imprimirCapital "Dempsey"


──────────────────────── ୨୧ ──────────────────────────

// 8 UNIONES DISCRIMINADAS and GROUPBY EJEMPLO BANCOS

type Moneda = 
    | Pesos
    | Dolares
    | Euros



type Banco = {
    Banco: string
    Moneda: Moneda
    Balance: decimal
}


let cuentas = [

    {
    Banco= "Bancolombia"
    Moneda= Pesos
    Balance = 200000m
    }
    {
    Banco= "Nu"
    Moneda= Dolares
    Balance = 6m // decimales tienen m al final
    }
    {
    Banco= "Cider"
    Moneda= Euros
    Balance = 20m // decimales tienen m al final
    }
    {
    Banco = "UBS"
    Moneda = Euros
    Balance = 2300m
    }
]


let agruparCuentas cuentas =
    cuentas
    |> List.groupBy (fun e -> e.Moneda)


agruparCuentas cuentas
|> List.iter (fun e -> printfn $"\n{e}")


// 9 CALCULAR TOTALES CUENTA

let calcularTotales cuentas =
    agruparCuentas cuentas
    |> List.map // transformo la lista de tuplas 
        (fun (moneda, lista) -> 
            lista
            |> List.map (fun r -> r.Balance) // me interesa el balance para sumarlo
            |> List.sum
            |> fun total -> moneda,total // A este le pasa la suma
        )

let totales = calcularTotales cuentas


printfn $"\n{totales}"


// 10 convertir y totalizar



let cambioMoneda moneda total =
    match moneda with
    | Dolares -> total
    | Pesos ->  total/4200m
    | Euros -> 1.14m*total


let totalizar cuentas =
    calcularTotales cuentas  
    |> List.map (fun (moneda,total) -> cambioMoneda moneda total)
    |> List.sum 


let dolarizado = totalizar cuentas

printfn $"\n{dolarizado}"