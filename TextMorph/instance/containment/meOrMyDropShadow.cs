meOrMyDropShadow
	^ (owner isKindOf: DropShadowMorph)
			ifTrue: [owner]
			ifFalse: [self]