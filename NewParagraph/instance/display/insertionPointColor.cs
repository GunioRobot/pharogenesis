insertionPointColor
	^ Display depth <= 2
		ifTrue: [Color black]
		ifFalse: [Preferences insertionPointColor]