Crear una base de datos de un directorio que contenga nombre, apellido, telefono, direccion e Email

con minimo 5 elementos (records)

Funciones a realizar:
1. Retorne por orden alfabetico de apellido todo el record
2. Busque por telefono y retorne todo el record
3. Retorne los telefonos organizados alfabeticamente por apellido.

type Directorio = 
    {
        Nombre: string
        Apellido: string
        Telefono: int
        Direccion: string
        Email: string
    }


let directorio = 
    [
        {
            Nombre = "Batman"
            Apellido ="Wayne"
            Telefono = 44881234
            Direccion = "El edificio wayne"
            Email = "No tengo"
        }
        {
            Nombre = "Bucky"
            Apellido ="Barnes"
            Telefono = 98678545
            Direccion = "Brooklyn"
            Email = "wintersoldier@aven.us"
        }
        {
            Nombre = "Peter"
            Apellido ="Quill"
            Telefono = 00000000
            Direccion = "Milano"
            Email = "starlord@guardian.nov"
        }
        {
            Nombre = "Chris"
            Apellido ="Williams"
            Telefono = 14000130
            Direccion = "Crra sur"
            Email = "c.will@gmail.com"
        }
        {
            Nombre = "Johan"
            Apellido ="Obrian"
            Telefono = 30311102
            Direccion = "Inglaterra"
            Email = "david-williams@gmail.com"
        }
    ]


// Punto 1 Retornar los Records organizados por Apellido.

let ordenAlfabetico (records: Directorio list) =
    records
    |> List.sortBy (fun r -> r.Apellido)

let resultado1 = ordenAlfabetico directorio

printfn "Por orden alfabetico de apellido:"
printfn $" {resultado1}"


// Punto 2 Retornar los Records organizados por telefono.

let ordenporTelefono (records: Directorio list) =
    records 
    |> List.sortBy (fun r -> r.Telefono)

let resultado2 = ordenporTelefono directorio

printfn ""
printfn "Por orden numerico del telefono:"
printfn $"{resultado2}"


// Punto 3 Retorne los telefonos ordenados por apellido.

let telefonorOrdenadosporApellido () =
    directorio 
    |> List.sortBy (fun r -> r.Apellido)
    |> List.map (fun r -> r.Telefono)

let resultado3 = telefonorOrdenadosporApellido ()

printfn ""
printfn "Telefonos ordenados por apellidos:"
printfn $"{resultado3}"

//Punto 2 corregido


let BusquedaporTelefono (records: Directorio list) telefono =
    records 
    |> List.tryFind (fun r -> r.Telefono = telefono)
        
let telefonodado =  98678545
let resultado4 = BusquedaporTelefono directorio telefonodado

printfn ""
printfn $"Buscar por telefono: {telefonodado}"
printfn $"{resultado4}"