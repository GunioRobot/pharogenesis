displayTranformation
	displayTransformation == nil
		ifTrue: [displayTransformation _ self computeDisplayTransformation].
	displayTransformation setScale: 1@1 translation: displayTransformation translation.
	^ displayTransformation