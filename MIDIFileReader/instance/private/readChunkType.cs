readChunkType
	"Read a 32-bit positive integer from the next 4 bytes, most significant byte first."
	"Assume: Stream has at least four bytes left."

	| s |
	s _ String new: 4.
	1 to: 4 do: [:i | s at: i put: (stream next) asCharacter].
	^ s
