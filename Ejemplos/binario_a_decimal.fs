// Binario a decimal 

let binarioDecimal (binario:string) =
    let rec conversión (numerob: string) posicion resdecimal =
        if posicion < 0 then 
            resdecimal
        else 
            match numerob.[posicion] with 
            | '0' -> conversión numerob (posicion-1) resdecimal
            | '1' -> conversión numerob (posicion-1)(resdecimal+(1 <<< (numerob.Length - 1 - posicion)))
            | _ -> failwith "Entrada invalida"

    if binario = null || binario = "" then
        0
    else 
        conversión binario (binario.Length - 1) 0

let resultado = binarioDecimal "110100"
printfn $"El número 1101 a decimal es= {resultado}"