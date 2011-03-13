save: characterStream
	"Submit the current text.  Equivalent to 'accept' 1/18/96 sw
	 Keeps typeahead."

	self closeTypeIn: characterStream.
	self terminateAndInitializeAround: [self accept].
	^ true