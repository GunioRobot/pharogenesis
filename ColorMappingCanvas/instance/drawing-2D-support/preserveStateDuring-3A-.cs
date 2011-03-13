preserveStateDuring: aBlock
	"Preserve the full canvas state during the execution of aBlock"
	| oldCanvas |
	oldCanvas := myCanvas.
	myCanvas preserveStateDuring:[:newCanvas|
		myCanvas := newCanvas.
		aBlock value: self].
	myCanvas := oldCanvas.