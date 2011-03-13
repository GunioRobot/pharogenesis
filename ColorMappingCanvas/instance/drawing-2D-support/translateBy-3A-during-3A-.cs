translateBy: delta during: aBlock
	"Set a translation only during the execution of aBlock."
	| oldCanvas |
	oldCanvas _ myCanvas.
	myCanvas translateBy: delta during:[:newCanvas|
		myCanvas _ newCanvas.
		aBlock value: self].
	myCanvas _ oldCanvas.