keyCharacter: aLetter atIndex: indexInQuote nextFocus: nextFocus

	(self letterMorphs at: indexInQuote) setLetter: aLetter.
	(cluesPanel letterMorphs at: indexInQuote) setLetter: aLetter.
	self highlight: nextFocus
