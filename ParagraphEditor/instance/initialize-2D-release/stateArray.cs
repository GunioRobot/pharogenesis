stateArray
	^ {ChangeText.
		FindText.
		UndoInterval.
		UndoMessage.
		UndoParagraph.
		UndoSelection.
		Undone.
		self selectionInterval.
		self startOfTyping.
		emphasisHere}