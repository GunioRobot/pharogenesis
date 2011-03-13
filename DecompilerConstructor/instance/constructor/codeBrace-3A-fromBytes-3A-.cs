codeBrace: numElements fromBytes: anInstructionStream

	^BraceConstructor new
		codeBrace: numElements
		fromBytes: anInstructionStream
		withConstructor: self