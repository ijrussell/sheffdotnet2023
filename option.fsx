open System

type Name = {
    FirstName : string
    MiddleName : string option
    LastName : string
}

let n1 = { FirstName = "Ian"; MiddleName = None; LastName = "Russell" }

let printName (name:Name) =
    // let defMiddleName = name.MiddleName |> Option.defaultValue ""
    printfn $"{name.FirstName} {name.MiddleName} {name.LastName}"

printName n1

// Interop with null

let s1 : string = null
let ns1 = Nullable<int>() 

let vs1 = s1 |> Option.ofObj
let vns1 = ns1 |> Option.ofNullable

let fs1 = vs1 |> Option.toObj
let fns1 = vns1 |> Option.toNullable






