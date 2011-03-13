commentArchive
	| newName |
	archive ifNil: [ ^self ].
	newName := FillInTheBlankMorph
			request: 'New comment for archive:'
			initialAnswer: archive zipFileComment
			centerAt: Sensor cursorPoint
			inWorld: self world
			onCancelReturn: archive zipFileComment
			acceptOnCR: true.
	archive zipFileComment: newName.