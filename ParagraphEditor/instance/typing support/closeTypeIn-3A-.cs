closeTypeIn: characterStream
	"Call instead of closeTypeIn when you want typeahead to be inserted before the
	 control character is executed, e.g., from Ctrl-V."

	self insertTypeAhead: characterStream.
	self closeTypeIn