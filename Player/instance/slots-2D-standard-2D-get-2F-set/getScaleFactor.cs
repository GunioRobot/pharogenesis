getScaleFactor

	| aCostume |
	^ (aCostume _ self costume) isFlexMorph
		ifTrue: [aCostume scale]
		ifFalse: [1.0]
