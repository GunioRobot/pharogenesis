undoCutCopy: oldPasteBuffer
	"Undo of a cut, copy, or any edit that changed CurrentSelection.  Be sure
	 undo-copy does not lock the model.  Redoer: itself, so never isRedoing."

	| recentCut |
	recentCut := self clipboardText.	
	UndoSelection size = UndoInterval size
		ifFalse: [self replaceSelectionWith: UndoSelection].
	self clipboardTextPut: oldPasteBuffer.
	self undoer: #undoCutCopy: with: recentCut