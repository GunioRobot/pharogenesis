keyCharacter: aLetter atIndex: indexInQuote nextFocus: nextFocus

	| encodedLetter |
	encodedLetter _ quote at: indexInQuote.
	originalMorphs with: decodingMorphs do:
		[:e :d | e letter = encodedLetter ifTrue: [d setLetter: aLetter color: Color red]].
