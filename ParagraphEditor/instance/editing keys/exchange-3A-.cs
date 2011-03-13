exchange: characterStream
	"Exchange the current and prior selections.  Keeps typeahead."

	self closeTypeIn: characterStream.
	self exchange.
	^true