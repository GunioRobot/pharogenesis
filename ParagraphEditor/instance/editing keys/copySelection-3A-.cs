copySelection: characterStream 
	"Copy the current text selection.  Flushes typeahead."

	sensor keyboard.		"flush character"
	self copySelection.
	^true