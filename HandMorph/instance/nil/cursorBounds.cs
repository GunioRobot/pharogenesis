cursorBounds

	temporaryCursor == nil
		ifTrue: [^ self position extent: NormalCursor extent]
		ifFalse: [^ self position + temporaryCursorOffset
								extent: temporaryCursor extent]