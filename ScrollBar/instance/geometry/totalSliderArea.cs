totalSliderArea
	^ bounds isWide
		ifTrue: [upButton bounds topRight corner: downButton bounds bottomLeft]
		ifFalse: [upButton bounds bottomLeft corner: downButton bounds topRight]