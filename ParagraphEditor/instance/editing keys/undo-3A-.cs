undo: characterStream 
	"Undo the last edit.  Keeps typeahead, so undo twice is a full redo."

	self closeTypeIn: characterStream.
	self undo.
	^true