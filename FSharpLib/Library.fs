namespace FSharpLib

module Maths =  
    exception MathsException of string

    let IsEven x =
        (x % 2) = 0

    let IsOdd x =
        (x % 2) <> 0

    let Add x y =
        x + y

    let Random x y =
        let rand = new System.Random()
        if x > y then
            rand.Next(y, x)
        else
            rand.Next(x, y)


type ILogin =
   abstract member IsValid: bool

type Login(id:int, username:string, password:string) =
    member this.Id = id
    member this.Username = username
    member this.Password = password
    interface ILogin with 
        member this.IsValid = this.Username = "cunt" && this.Password = "password"
