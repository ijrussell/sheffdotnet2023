// seq, List, Array
// Map, Set
// Array2D, Array3D
// 

// map, filter, reduce

let l1 = [1..10]

let even (input:int list) =
    input |> List.filter (fun x -> x % 2 = 0)

even l1

let double = [1..10] |> List.map (fun x -> x * 2)

let sum = [1..10] |> List.reduce (fun acc v -> acc + v)

let sumEmpty = [] |> List.reduce (fun acc v -> acc + v) 

let safeSum (defaultValue:int) (input:int list) =
    match input with
    | [] -> defaultValue
    | _ -> input |> List.reduce (fun acc v -> acc + v) 

safeSum 0 []
safeSum 0 [1..10]

let x = [] |> List.sum

let recSum (input:int list) =
    let rec loop acc next =
        match next with
        | [] -> acc
        | h::tail -> loop (acc + h) tail
    loop 0 input

recSum []
recSum [1..10]

let sum1 = [1..10] |> List.fold (fun acc v -> acc + v) 0
let sum2 = (0, [1..10]) ||> List.fold (fun acc v -> acc + v)

[1..20] |> List.chunkBySize 5
[1..10] |> List.windowed 5

// Arrays
let a1 = [|1;2|]

a1[0] = 5 // false

a1[0] <- 5 // unit

a1[0] = 5 // true

a1 // [|5;2|]

Array.init 5 (fun i -> i)

Array.create 0










