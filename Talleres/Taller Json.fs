// Taller 

// Serializar (de nativo a json)

type Ciudadano = {
    Nombre: string
    Cedula: int
}


let lista = [ 
        {
            Nombre = "Madelein"
            Cedula = 3
        }
        {
            Nombre = "Kelly"
            Cedula = 4
        }
        {
            Nombre = "Mariana"
            Cedula = 5
        }
]

let serializeCiudadano x =
    """ {"Nombre:" """ + "\"" + x.Nombre + "\"," + """, "Cedula:" """ + $"{x.Cedula}" + "} "
    // \ scape me deja poner una comilla verdadera

let r = serializeCiudadano lista[2]
printf $"{r}"


let serealizarLista lista =
    lista 
    |> Seq.map serializeCiudadano
    |> Seq.reduce (fun acc e -> $"{acc}, {e}") // Reduce siempre tiene valor inicial primer elemento. Aquí agrego una "," que separa
    |> fun x -> $"[{x}]"

let r2 = serealizarLista lista 
printf $"{r2}"