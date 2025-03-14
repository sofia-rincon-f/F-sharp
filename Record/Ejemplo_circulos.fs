type Circle ={
      Radius: float
      Color: string 
      Pen: int
    }



let compareCircles c1 c2 =
    if c1.Radius > c2.Radius 
    then
        c1
    else 
        c2

let circleOne = 
    {
        Radius = 2.0; 
        Color = "blue"; 
        Pen = 2
    }

let circleTwo = {circleOne with Radius = 0.8; Color = "yellow"}

let result = compareCircles circleOne circleTwo
printfn $"{result}"