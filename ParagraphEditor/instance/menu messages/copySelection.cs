copySelection
	"Copy the current selection and store it in the paste buffer, unless a caret.  Undoer & Redoer: undoCutCopy:.
	 2/29/96 sw: select line first, if selection was an insertion point"

	self selectLine.
	startBlock = stopBlock ifTrue: [^ view flash.].

	"Simulate 'substitute: self selection' without locking the controller"
	UndoSelection _ self selection.
	self undoer: #undoCutCopy: with: self clipboardText.
	UndoInterval _ self selectionInterval.
	self clipboardTextPut: UndoSelection