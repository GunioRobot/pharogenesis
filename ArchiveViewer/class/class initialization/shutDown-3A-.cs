shutDown: quitting
	quitting ifTrue: [ self deleteTemporaryDirectory ].