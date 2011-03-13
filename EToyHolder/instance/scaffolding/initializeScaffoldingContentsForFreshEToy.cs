initializeScaffoldingContentsForFreshEToy
	"This is done for a fresh e-toy, not for one being loaded from disk"

	self scaffoldingTabInfo doWithIndex:
		[:quad :index |
			scaffoldingBook addTabNamed: quad first color: (Color perform: quad second)
				atIndex: index.
			self setInitialContentForScaffoldingTabNamed: quad first fromSelector: quad third].

	EToyParameters fullEToyGraphics ifTrue: [self addDemoContentsToMailTab].
	self addDemoContentsToSqueakTab.
	EToyParameters fullEToyGraphics ifTrue: [self addDemoContentsToImagineersTab].
	scaffoldingBook fullBounds.
