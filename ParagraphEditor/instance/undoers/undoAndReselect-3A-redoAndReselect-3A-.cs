undoAndReselect: undoHighlight redoAndReselect: redoHighlight
	"Undo typing, cancel, paste, and other operations that are like replaces
	 but the selection is not the whole restored text after undo, redo, or both.
	 undoHighlight is selected after this phase and redoHighlight after the next phase.
	Redoer: itself."

	self replace: self selectionInterval with: UndoSelection and:
		[self selectInterval: undoHighlight].
	self undoMessage: (UndoMessage argument: redoHighlight) forRedo: self isUndoing
