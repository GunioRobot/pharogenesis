exchange: characterStream
	"Exchange the current and prior selections.  Keeps typeahead."

	sensor keyboard.	 "Flush character"
	self closeTypeIn: characterStream.
	self exchange.
	^true