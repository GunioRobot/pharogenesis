doubleClick: evt
	| palette |
	palette _ self standardPalette.
	((palette notNil and: [palette isInWorld]) and: [palette hasScrapsTab])
		ifTrue:
			[palette showScrapsTab]
		ifFalse:
			[self world openScrapsBook: evt].