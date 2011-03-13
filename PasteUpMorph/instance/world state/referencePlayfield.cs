referencePlayfield
	"Answer a pasteup morph to be used as the reference for cartesian coordinates"

	self isWorldMorph
		ifTrue: [^ self submorphNamed: 'playfield' ifNone: [self]]
		ifFalse: [^ super referencePlayfield]