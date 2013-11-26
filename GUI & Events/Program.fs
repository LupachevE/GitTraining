open System
open System.Windows.Forms
open System.Drawing

let mutable balance = 0

let draw(this : string) =
  printfn "%A" 1

type Cars(price : int, model : string) =
  
  let price = price
  let model = model
  member this.Price = price
  member this.Model = model
  member this.IsEnough(balance : int) = balance >= price 
  member this.Draw(model) =
    match model with
    | "Audi"       -> draw("Audi")
    | "Toyota"     -> draw("Toyota")
    | "Honda"      -> draw("Honda")
    | "Volkswagen" -> draw("Volkswagen")
    | "Ford"       -> draw("Ford")
    | "Mitsubishi" -> draw("Mitsubishi")
    | "Mersedes"   -> draw("Mersedes")
    | _            -> draw("Nothinng")

let OnFeet = new Cars(0, "Foot")
let Audi = new Cars(1000, "Audi")
let Toyota = new Cars(5000, "Toyota")
let Honda = new Cars(15000, "Honda")
let Volkswagen = new Cars(30000, "VolksWagen")
let Ford = new Cars(100000, "Ford")
let Mitsubishi = new Cars(300000, "Mitsubishi")
let Mersedes = new Cars(1000000, "Mersedes")

let CarForm = 
    
    let form = new Form(Text = "Choosing the car")
    let button = new Button(Text = "Huy", Left = 10,
                                Top = 10, Width = 80, Enabled = true)

    form

let LuckyForm = 
    
    let form = new Form(Text = "Lucky or Not")
    let button = new Button(Text = "Press it!", Left = 400,
                            Top = 600, Width = 80, Enabled = true)
    form

let mainForm = 

    //if not (this.IsEnough(balance)) then button.Enabled <- not button.Enabled

    let form = new Form(Text = "Cars&Money")

    let firstbutton = new Button(Text = "ChooseYourCar", Left = 10,
                                 Top = 10, Width = 100, Enabled = true)
    let secondbutton = new Button(Text = "TestYourLuck", Left = 150,
                                  Top = 10, Width = 100, Enabled = true)
             
                                                                                                
    let buttonPress1 _ _ = LuckyForm.ShowDialog |> ignore
    let buttonPress2 _ _ = CarForm.ShowDialog |> ignore

    let eventHandler1 = new EventHandler(buttonPress1)
    let eventHandler2 = new EventHandler(buttonPress2)

    firstbutton.Click.AddHandler(eventHandler1)
    secondbutton.Click.AddHandler(eventHandler2) 

    let dc c = (c :> Control)

    form.Controls.AddRange([| dc firstbutton; dc secondbutton;|])

    form

do Application.Run(mainForm)