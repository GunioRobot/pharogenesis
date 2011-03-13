replaceSelectionWith: aText
	"Remember the selection text in UndoSelection.
	 Deselect, and replace the selection text by aText.
	 Remember the resulting selectionInterval in UndoInterval and PriorInterval.
	 Set up undo to use UndoReplace."

	beginTypeInBlock ~~ nil ifTrue: [^self zapSelectionWith: aText]. "called from old code"
	UndoSelection _ self selection.
	self zapSelectionWith: aText.
	self undoer: #undoReplace