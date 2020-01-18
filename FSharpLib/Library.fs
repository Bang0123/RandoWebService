namespace FSharpLib

module Maths =

    type Maths() =  
        member this.IsEven x =
            x % 2 = 0

        member this.IsOdd x =
            x % 2 <> 0
