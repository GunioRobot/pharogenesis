getCharacterAtCursor
	"Answer the value of the text cursor"

	| aLoc aTextMorph aString |
	aLoc _ (aTextMorph _ self costume renderedMorph) cursor.
	aString _ aTextMorph text string.
	^ (aString at: aLoc ifAbsent: ['·']) asString