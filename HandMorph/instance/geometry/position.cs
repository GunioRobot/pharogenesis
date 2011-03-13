position

	temporaryCursorOffset ifNil: [temporaryCursorOffset _ 0@0].
	^ bounds topLeft + temporaryCursorOffset
