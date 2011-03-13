preserveStateDuring: aBlock
	"Preserve the full canvas state during the execution of aBlock"
	| oldCanvas |
	oldCanvas _ myCanvas.
	myCanvas preserveStateDuring:[:newCanvas|
		myCanvas _ newCanvas.
		aBlock value: self].
	myCanvas _ oldCanvas.