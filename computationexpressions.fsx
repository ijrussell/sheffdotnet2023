// Task: Caclulate ((x / y) * x) / y

// int -> int -> int
let multiply (x:int) (y:int) = 
    x * y

// int -> int -> int option
let divide (x:int) (y:int) = 
    if y = 0 then None
    else Some (x / y)

// The formula is: f x y = ((x / y) * x) / y
let calculate x y =
    divide x y
    |> fun r1 -> multiply r1 x // compiler error
    |> fun r2 -> divide r2 y

// Expand out 
let calculate1 x y =
    divide x y
    |> fun r1 -> 
        match r1 with
        | Some v -> Some (multiply v x)
        | None -> None
    |> fun r2 -> 
        match r2 with
        | Some t -> divide t y
        | None -> None

let calculate2 x y =
    divide x y
    |> Option.map (fun r1 -> multiply r1 x)
    |> Option.bind (fun r2 -> divide r2 y)

// Warning - It looks like magic but it isn't!

[<AutoOpen>]
module Option =
    type OptionBuilder() =
    // Supports let!
        member _.Bind(x, f) = Option.bind f x
        // Supports return
        member _.Return(x) = Some x
        // Supports return!
        member _.ReturnFrom(x) = x

// Computation Expression for Option
// Usage will be option {...}
let option = OptionBuilder()


let calculate3 x y =
    option {
        let! v = divide x y
        let t = multiply v x
        let! r = divide t y
        return r
    }

let good = calculate3 10 5

let bad = calculate3 10 0

