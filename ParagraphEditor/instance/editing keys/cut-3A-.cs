cut: characterStream 
	"Cut out the current text selection.  Flushes typeahead."

	sensor keyboard.		"flush character"
	self cut.
	^true