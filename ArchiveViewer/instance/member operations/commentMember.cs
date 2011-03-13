commentMember
	| newName |
	newName := FillInTheBlankMorph
			request: 'New comment for member:'
			initialAnswer: self selectedMember fileComment
			centerAt: Sensor cursorPoint
			inWorld: self world
			onCancelReturn: self selectedMember fileComment
			acceptOnCR: true.
	self selectedMember fileComment: newName.