openTypeIn
	"Set up UndoSelection to null text (to be added to by readKeyboard and backTo:),
	 beginTypeInBlock to keep track of the leftmost backspace, and UndoParameter to tally
	 how many deleted characters were backspaced over rather than 'cut'.
	 You can't undo typing until after closeTypeIn."

	beginTypeInBlock == nil ifTrue:
		[UndoSelection _ self nullText.
		self undoer: #noUndoer with: 0.
		beginTypeInBlock _ self startIndex]