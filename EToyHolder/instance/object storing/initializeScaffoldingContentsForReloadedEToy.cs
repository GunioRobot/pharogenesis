initializeScaffoldingContentsForReloadedEToy
	"This is done for an EToy reloaded from disk, not for one created from cold code"

	| tabName tabBook |
	self tabsNotToStore do:
		[:quad  |
			tabName _ quad first withBlanksTrimmed.
			tabBook _ scaffoldingBook pageNamed: tabName.
			tabBook ifNotNil: "Stored in the file as a place-holder; fill it in"
				[self setInitialContentForScaffoldingTabNamed: tabName fromSelector: quad third]].

	"rename tabs"
	scaffoldingBook tabsMorph stringButtonSubmorphs do: [:tab |
		(tab contents beginsWith: 'Help') ifTrue: [tab contents: 'Squeak   '].
		(tab contents beginsWith: 'Painting') ifTrue: [tab contents: 'Imagis']].

	self addDemoContentsToMailTab.
	self addDemoContentsToSqueakTab.
	self addDemoContentsToImagineersTab.
	scaffoldingBook fullBounds.
