pasteMorph

	| aPastee |
	PasteBuffer ifNil: [^ self inform: 'Nothing to paste.'].
	self attachMorph: (aPastee _ self objectToPaste).
	aPastee align: aPastee center with: self position.
	aPastee player ifNotNil: [aPastee player startRunning]
