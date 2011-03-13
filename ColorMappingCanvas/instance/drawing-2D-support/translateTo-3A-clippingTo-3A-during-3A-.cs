translateTo: newOrigin clippingTo: aRectangle during: aBlock
	"Set a new origin and clipping rectangle only during the execution of aBlock."
	| oldCanvas |
	oldCanvas _ myCanvas.
	myCanvas translateTo: newOrigin clippingTo: aRectangle during:[:newCanvas|
		myCanvas _ newCanvas.
		aBlock value: self].
	myCanvas _ oldCanvas.