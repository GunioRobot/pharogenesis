justDroppedInto: aMorph event: anEvent
	| relPosition |
	relPosition _ self position - aMorph innerBounds topLeft.
	relPosition _ (relPosition x roundTo: 8) @ relPosition y.
	self position: aMorph innerBounds topLeft + relPosition.
	sound copy play.
	^super justDroppedInto: aMorph event: anEvent