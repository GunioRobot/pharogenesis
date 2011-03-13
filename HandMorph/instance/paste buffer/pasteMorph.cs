pasteMorph

	| aPastee |
	PasteBuffer ifNil: [^ self inform: 'Nothing to paste.' translated].
	self attachMorph: (aPastee _ self objectToPaste).
	aPastee align: aPastee center with: self position.
	aPastee player ifNotNil: [aPastee player startRunning]
