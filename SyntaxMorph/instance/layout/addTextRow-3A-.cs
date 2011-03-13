addTextRow: aStringLikeItem

	| row |
	(row _ self class row: #text on: nil) borderWidth: 1.
	row addMorph: (self addString: (aStringLikeItem copyWithout: Character cr)).
	self addMorphBack: row.
	^row