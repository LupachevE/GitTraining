(*type AccountState = 
    | Overdrawn
    | Silver
    | Gold
type Account() =
    let mutable balance = 0.0   
    member this.State
        with get() = 
            match balance with
            | _ when balance <= 0.0 -> Overdrawn
            | _ when balance > 0.0 && balance < 10000.0 -> Silver
            | _ -> Gold
    member this.PayInterest() = 
        let interest = 
            match this.State with
                | Overdrawn -> 0.0
                | Silver -> 0.01
                | Gold -> 0.02
        interest * balance
    member this.Deposit(x:float) =  
        let (a:float) = x
        balance <- balance + a
    member this.Withdraw(x:float) = balance <- balance - x

let account = Account()

account.Deposit(50000.0)
printfn "interest = %A" (account.PayInterest())

account.Withdraw(20000.0)
printfn "interest = %A" (account.PayInterest())*)
   
type State() =
    member this.goNext(balance) =
            match balance with
            | _ when balance <= 0.0 -> new Overdrawn() :> State
            | _ when balance > 0.0 && balance < 10000.0 -> new Silver() :> State
            | _ -> new Gold() :> State

and Overdrawn() =
    inherit State()

and Gold() =
    inherit State()

and Silver() =
    inherit State()


type Account() =
    let mutable balance = 0.0
    let mutable (currentState : State) = new Overdrawn() :> State
    member this.PayInterest() = 
        let interest = 
            match currentState with
                | :? Overdrawn -> 0.0
                | :? Silver -> 0.01
                | :? Gold -> 0.02 
        interest * balance
    member this.Deposit(x:float) =  
        let (a:float) = x
        balance <- balance + a
        currentState <- currentState.goNext(balance)
    member this.Withdraw(x:float) = 
        balance <- balance - x
        currentState <- currentState.goNext(balance)

let account = Account()

account.Deposit(10000.0)
printfn "interest = %A" (account.PayInterest())

account.Withdraw(20000.0)
printfn "interest = %A" (account.PayInterest())