pasteMorph

	| aPastee |
	PasteBuffer ifNil: [^ self inform: 'Nothing to paste.' translated].
	self attachMorph: (aPastee := self objectToPaste).
	aPastee align: aPastee center with: self position.
	