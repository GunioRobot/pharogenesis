cut
	"Cut out the current selection and redisplay the paragraph if necessary.  Undoer & Redoer: undoCutCopy:.
	2/29/96 sw: select line first, if selection was an insertion point"

	self selectLine.
	startBlock = stopBlock ifTrue: [^ view flash].

	self replaceSelectionWith: self nullText. 
	self undoer: #undoCutCopy: with: self clipboardText.
	self clipboardTextPut: UndoSelection