save: characterStream 
	"Submit the current text.  Equivalent to 'accept' 1/18/96 sw
	 Keeps typeahead."

	sensor keyboard.		"flush character"
	self closeTypeIn: characterStream.
	self accept.
	^ true