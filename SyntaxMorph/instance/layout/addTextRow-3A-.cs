addTextRow: aStringLikeItem

	| row tt |
	(row _ self class row: #text on: nil) borderWidth: 1.
	(tt _ TextMorph new) contents: aStringLikeItem.
	row addMorph: tt.
	"row addMorph: (self addString: (aStringLikeItem copyWithout: Character cr) special: false)."
	self addMorphBack: row.
	^row