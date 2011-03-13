undoReplace
	"Undo of any command that replaced a selection by other text that it left
	 highlighted, and that is undone and redone by simple reversal of the
	 operation.  This is the most common Undoer; call replaceSelectionWith:
	 to get this setup.  Redoer: itself, so never isRedoing."

	self replaceSelectionWith: UndoSelection