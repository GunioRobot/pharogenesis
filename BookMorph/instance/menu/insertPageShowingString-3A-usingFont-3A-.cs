insertPageShowingString: aString usingFont: aFont 
	"For creating text content on a page of a BookMorph, from cold code.  Sadly, can't yet specify font..."

	self insertPage.
	currentPage addMorph:
		(TextMorph new extent: (self extent - (12@0)); contentsWrapped: aString)