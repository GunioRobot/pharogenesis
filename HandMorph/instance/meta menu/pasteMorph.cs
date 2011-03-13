pasteMorph

	| aPastee |
	PasteBuffer ifNil: [^ self inform: 'Nothing to paste.'].
	self attachMorph: (aPastee _ PasteBuffer usableDuplicate).
	aPastee costumee ifNotNil: [aPastee costumee startRunning]
