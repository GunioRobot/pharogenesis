sourceClass
	"Get my receiver class (method class) from the preamble of my source.  Return nil if not found."

	^ [| theFile |
		theFile := self sourceFileStream.
		[(Compiler evaluate: (theFile backChunk "blank"; backChunk "preamble")) theClass] ensure: [theFile close]] on: Error do: [nil]