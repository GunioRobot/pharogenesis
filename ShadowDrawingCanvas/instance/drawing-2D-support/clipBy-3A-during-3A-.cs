clipBy: aRectangle during: aBlock
	"Set a clipping rectangle active only during the execution of aBlock.
	Note: In the future we may want to have more general clip shapes - not just rectangles"
	| oldCanvas |
	oldCanvas _ myCanvas.
	myCanvas clipBy: aRectangle during:[:newCanvas|
		myCanvas _ newCanvas.
		aBlock value: self].
	myCanvas _ oldCanvas