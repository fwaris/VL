module MainScreen

open MonoTouch.UIKit
open VL

let genView () = 

    let btnLbls = ["TopLeft"; "TopRight"; "BottomLeft"; "BottomRight"]

    let btns =
        [|for l in btnLbls do
            let bbtn = UIButton.FromType(UIButtonType.System) 
            bbtn.Layer.BorderColor  <- UIColor.Blue.CGColor
            bbtn.Layer.BorderWidth  <- 1.f
            bbtn.Layer.CornerRadius <- 5.f
            bbtn.SetTitle(l, UIControlState.Normal)
            yield bbtn |]

    let bTopLeft, bTopRight, bBottomLeft, bBottomRight = btns.[0], btns.[1], btns.[2], btns.[3]

    let cntntTbl = new UITableView()
    cntntTbl.BackgroundColor <- UIColor.LightGray
    cntntTbl.ScrollEnabled <- true

    //constraints
    let cth = H [ !- 2. ; !@ bTopLeft   ; !->= 5.1; !@ bTopRight   ; !- 2.]      //anchor horizontally
    let cbh = H [ !- 2. ; !@ bBottomLeft; !->= 5.2; !@ bBottomRight; !- 2.]
 
    let clv = V [ !- 20.; !@ bTopLeft; !->= 5.3; !@ bBottomLeft; !- 2.]
    let crv = V [ !- 20.; !@ bTopRight; !->= 5.4; !@ bBottomRight; !- 2.]

    let c5 = H [!- 40. ; !@ cntntTbl @@ [!!> 5.5]; !- 40.]
    let c6 = V [!- 60. ; !@ cntntTbl @@ [!!> 5.6]; !- 40.]
   
    //creates the container view
    //all views referenced in the constraints
    //are added as subviews    
    let cs =  [cth; cbh; clv; crv; c5; c6]
    let cstrs = cs |> List.map VL.genConstraintString

    cntntTbl.Source <- 
        {new UITableViewSource() with
            override x.RowsInSection(t,i) = cstrs.Length
            override x.GetCell(t,p) =
                let c = 
                    match t.DequeueReusableCell("tbl") with
                    | null -> new UITableViewCell (UITableViewCellStyle.Default, "tbl")
                    | c    -> c
                c.TextLabel.Text <- fst cstrs.[p.Row] 
                c
        }
    package cs
