replace: oldInterval with: newText and: selectingBlock 
	"Replace the text in oldInterval with newText and execute selectingBlock to establish the new selection.  Create an undoAndReselect:redoAndReselect: undoer to allow perfect undoing."

	| undoInterval |
	undoInterval _ self selectionInterval.
	undoInterval = oldInterval ifFalse: [self selectInterval: oldInterval].
	UndoSelection _ self selection.
	self zapSelectionWith: newText.
	selectingBlock value.
	otherInterval _ self selectionInterval.
	self undoer: #undoAndReselect:redoAndReselect: with: undoInterval with: otherInterval