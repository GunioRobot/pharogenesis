zapSelectionWith: aText
	"Note edit except during typeIn, which notes edits at close."

	super zapSelectionWith: aText.
	beginTypeInBlock == nil ifTrue: [self userHasEdited].
