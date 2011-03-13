buttonLabel
	^ shortLabel
		ifNil: [self text]
		ifNotNil: [shortLabel ifEmpty: [self text] ifNotEmpty: [shortLabel]]