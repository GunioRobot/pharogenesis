setCharacterAtCursor: aCharOrString
	"Insert the given character at my cursor position"

	| aLoc aTextMorph aString charToUse |
	aLoc _ (aTextMorph _ self costume renderedMorph) cursor.
	charToUse _ (aString _ aCharOrString asString) size > 0
		ifTrue:
			[aString first]
		ifFalse:
			['·'].
	aTextMorph paragraph replaceFrom: aLoc to: aLoc with: charToUse asString asText displaying: true.
	aTextMorph updateFromParagraph  