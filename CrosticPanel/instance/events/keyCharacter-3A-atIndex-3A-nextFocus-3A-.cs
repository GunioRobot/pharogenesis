keyCharacter: aLetter atIndex: indexInQuote nextFocus: nextFocus

	(self letterMorphs at: indexInQuote) setLetter: aLetter.
	(quotePanel letterMorphs at: indexInQuote) setLetter: aLetter.
	self highlight: nextFocus
