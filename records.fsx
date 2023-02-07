open System

type GpsCoordinate = {
    Latitude : float
    Longitude : float
}

let g1 = { Latitude = 15.0; Longitude = 0 }
let g2 = { Latitude = 15.0; Longitude = 0 }

// Structural equality
g2 = g1



type ContactId = ContactId of Guid
type PhoneNumber = PhoneNumber of string
type EmailAddress = EmailAddress of string

// ValueType - Equality by structure
let c1 = ContactId (Guid.NewGuid())
let c2 = ContactId (Guid.NewGuid())
// deconstruct
let (ContactId id) = c1
// structural equality
let c3 = ContactId id

printfn "%A" (c1 = c2) // false
printfn "%A" (c1 = c3) // true

// Entity - Equality by Id
[<CustomEquality; NoComparison>]
type Contact = {
    ContactId : ContactId
    PhoneNumber : PhoneNumber
    EmailAddress: EmailAddress
}
with
    override this.Equals(obj) =
        match obj with
        | :? Contact as c -> this.ContactId = c.ContactId
        | _ -> false
    override this.GetHashCode() =
        hash this.ContactId

let cn1 = { 
    ContactId = ContactId id
    PhoneNumber = PhoneNumber "000-555-1234"
    EmailAddress = EmailAddress "ian@test.org"
}

let cn2 = { cn1 with EmailAddress = EmailAddress "help@test.org" }

printfn "%A" (cn1 = cn2) // true



