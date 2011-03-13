arrowAction: delta
	| phrase aPlayer newItem |
	(phrase _ self ownerThatIsA: PhraseTileMorph) ifNil: [^ self].
	aPlayer _ phrase associatedPlayer.
	newItem _ delta > 0
		ifTrue:
			[aPlayer menuItemAfter: literal]
		ifFalse:
			[aPlayer menuItemBefore: literal].
	self literal: newItem.
	self layoutChanged