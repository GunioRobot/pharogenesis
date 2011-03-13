localName

	directory isEmpty ifTrue: [self error: 'no directory'].
	^ self localNameFor: directory.