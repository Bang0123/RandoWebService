namespace FSharpLib


module Maths =  
    let IsEven x =
        x % 2 = 0

    let IsOdd x =
        x % 2 <> 0

    let Add x y =
        x + y


type ILogin =
   abstract member IsValid: bool

type Login(id:int, username:string, password:string) =
    member this.Id = id
    member this.Username = username
    member this.Password = password
    interface ILogin with 
        member this.IsValid = this.Username = "connel" && this.Password = "password"
