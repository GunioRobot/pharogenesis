referencePlayfield

	self isWorldMorph
		ifTrue: [^ self submorphNamed: 'playfield']
		ifFalse: [^ super referencePlayfield]