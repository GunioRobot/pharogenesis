balloonColor
	^ Display depth <= 2
		ifTrue: [Color white]
		ifFalse: [Color r: 1.0 g: 1.0 b: 0.6]