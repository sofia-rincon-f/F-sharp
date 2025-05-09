// For more information see https://aka.ms/fsharp-console-apps
open System.Net.Http
open System.Text.Json


type Person =
    {
        birth_year: int option
        death_year: int option
        name: string
    }

type Book = 
    {
        id: int
        title: string
        subjects: string array
        authors: Person array 
        sumaries: string array
        translators: Person array
        bookshelve: string array
        languages: string array
        copyright: bool option
        media_type : string
        formats: Map<string,string>
        dowload_count: int
    }

type Answer = 
    {
        count: int
        next: string option
        previous: string option 
        results: Book array
    }

let getURLAsync (url:string) =
    task {
        use client = new HttpClient()
        let! response = client.GetAsync url
        let! body = response.Content.ReadAsStringAsync()
        return body
    }

let getURL = getURLAsync >> Async.AwaitTask >> Async.RunSynchronously

//
// Obtener libros del Project Gutemberg
//
let demoUrl = @"https://gutendex.com/books?search=Verne%20Moon"

let result = getURL demoUrl

// prompt (files) - cursor terminal 

// 20% space en la url


let answer = JsonSerializer.Deserialize<Answer>result
printfn $"Total de libros: {answer.count}"


printfn "-------Titulo-------"
answer.results
|> Seq.iter (fun book -> printfn $"Titulo: {book.title}")


// Investigar como sacar el primer capitulo del primer libro (pista formats)