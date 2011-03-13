copySelection
	"Copy the current selection and store it in the paste buffer, unless a caret.  Undoer & Redoer: undoCutCopy"

	self lineSelectAndEmptyCheck: [^ self].

	"Simulate 'substitute: self selection' without locking the controller"
	UndoSelection := self selection.
	self undoer: #undoCutCopy: with: self clipboardText.
	UndoInterval := self selectionInterval.
	self clipboardTextPut: UndoSelection