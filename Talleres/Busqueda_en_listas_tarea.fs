- Crear una función que tome un país como parametro y retorne la capital de ese país.
- Imprimir la respuesta.
- ¿Qué pasa si se llama la función con un país que no está en la base de datos?

// Busqueda

let paises = [
    ("colombia", "bogotá")
    ("Francia", "París")
    ("España", "Madrid")
    ("Azerbaiyán", "Bakú")
    ("Alemania", "Berlín")
    ("Japón", "Tokio")
]

let buscarCapital pais =
    let (_, capital)= 
        atlas 
        |> List.find (fun (p,_)->p=pais)
    capital


let result = buscarCapital "Japón"
printf $"{result}"