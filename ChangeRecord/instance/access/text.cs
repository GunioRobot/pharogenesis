text
	| text |
	^ file ifNil: ['']
		ifNotNil: [
			file openReadOnly.
			file position: position.
			text _ file nextChunkText.
			file close.
			text]