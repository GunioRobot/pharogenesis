paste: characterStream 
	"Replace the current text selection by the text in the shared buffer.
	 Keeps typeahead."

	sensor keyboard.		"flush character"
	self closeTypeIn: characterStream.
	self paste.
	^true