cut
	"Cut out the current selection and redisplay the paragraph if necessary.  Undoer & Redoer: undoCutCopy:"

	self lineSelectAndEmptyCheck: [^ self].

	self replaceSelectionWith: self nullText. 
	self undoer: #undoCutCopy: with: self clipboardText.
	self clipboardTextPut: UndoSelection