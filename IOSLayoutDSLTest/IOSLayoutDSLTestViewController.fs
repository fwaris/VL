namespace IOSLayoutDSLTest

open System
open System.Drawing

open MonoTouch.UIKit
open MonoTouch.Foundation

[<Register ("IOSLayoutDSLTestViewController")>]
type IOSLayoutDSLTestViewController () =
    inherit UIViewController ()

    // Release any cached data, images, etc that aren't in use.
    override this.DidReceiveMemoryWarning () =
        base.DidReceiveMemoryWarning ()

    // Perform any additional setup after loading the view, typically from a nib.
    override this.ViewDidLoad () =
        base.ViewDidLoad ()
        this.View <- MainScreen.genView()
        this.View.BackgroundColor <- UIColor.White
        this.UpdateViewConstraints()

    // Return true for supported orientations
    override this.ShouldAutorotateToInterfaceOrientation (orientation) =
        orientation <> UIInterfaceOrientation.PortraitUpsideDown

