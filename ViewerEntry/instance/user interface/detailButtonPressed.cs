detailButtonPressed
	helpPane
		ifNotNil:
			[helpPane delete.
			helpPane _ nil]
		ifNil:
			[self addHelpPane]