addAColumn: aCollectionOfMorphs

	| col |
	col _ self inAColumn: aCollectionOfMorphs.
	self addMorphBack: col.
	^col