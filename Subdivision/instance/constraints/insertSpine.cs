insertSpine
	| ptList start end |
	ptList _ WriteStream on: (Array new: 100).
	self edgesDo:[:e|
		(e isBorderEdge or:[e isExteriorEdge]) ifFalse:[
			start _ e origin.
			end _ e destination.
			ptList nextPut: (start + end * 0.5).
		].
	].
	ptList contents do:[:pt| self insertPoint: pt].