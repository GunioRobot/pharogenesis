pixelValueAt: aPoint 
	"Return the raw pixel value at coordinate aPoint.  Depends on the form's depth.  Use colorAt: instead to get a Color.  6/20/96 tk"

	^ (BitBlt bitPeekerFromForm: self) pixelAt: aPoint