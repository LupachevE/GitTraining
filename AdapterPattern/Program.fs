open System

type Animals() =
    class end

type Cat() =
    inherit Animals()

type Dog() =
    inherit Animals()

type Adaptee() =
    member this.Walkdog() = printfn "Dog walks"
    member this.Walkcat() = printfn "Cat walks"

and Adapter() =
    let adaptee = new Adaptee()
    member this.Request(that : Animals) = 
        match that with
        | :? Cat -> adaptee.Walkcat()
        | :? Dog -> adaptee.Walkdog()

and Target() =
    let adapter = new Adapter()
    member this.request(that : Animals) = adapter.Request(that)

let littleKitty = new Cat() :> Animals
let target = new Target()
target.request(littleKitty)