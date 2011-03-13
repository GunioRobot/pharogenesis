addARow: aCollectionOfMorphs

	| row |
	row _ self inARow: aCollectionOfMorphs.
	self addMorphBack: row.
	^row