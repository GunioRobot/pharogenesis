undo: characterStream 
	"Undo the last edit.  Keeps typeahead, so undo twice is a full redo."

	sensor keyboard. 	"flush character"
	self closeTypeIn: characterStream.
	self undo.
	^true