insertPageShowingString: aString fontName: aName fontSize: aSize
	"For creating text content on a page of a BookMorph, from cold code.  Sadly, can't yet specify font..."
	| aTextMorph tempContents |
	self insertPage.
	aTextMorph _ TextMorph new.
	aTextMorph extent: (self extent - (12@0)).
	aName ifNotNil:
			[aTextMorph string: aString fontName: aName size: aSize]
		ifNil:
			[aTextMorph contentsWrapped: aString].
	tempContents _ aTextMorph contents.
	aTextMorph contentsWrapped: '-'.
	aTextMorph extent: (self extent - (12@0)).
	aTextMorph contentsWrapped: tempContents.

	currentPage addMorph: aTextMorph.