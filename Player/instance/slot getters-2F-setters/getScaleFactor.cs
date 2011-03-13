getScaleFactor
	"Answer the scale factor of the object"

	| aCostume |
	^ (aCostume _ self costume) isFlexMorph
		ifTrue: [aCostume scale]
		ifFalse: [1.0]
