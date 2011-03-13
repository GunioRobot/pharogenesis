translateBy: delta clippingTo: aRectangle during: aBlock
	"Set a translation and clipping rectangle only during the execution of aBlock."
	| oldCanvas |
	oldCanvas _ myCanvas.
	myCanvas translateBy: delta clippingTo: aRectangle during:[:newCanvas|
		myCanvas _ newCanvas.
		aBlock value: self].
	myCanvas _ oldCanvas.