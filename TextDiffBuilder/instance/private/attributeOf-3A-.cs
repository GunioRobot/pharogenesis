attributeOf: type
	"Private. Answer a TextAttribute that is used to display text of the given type."

	type == #insert ifTrue: [^ TextColor red].
	type == #remove ifTrue: [^ TextEmphasis struckOut].
	^ TextEmphasis normal