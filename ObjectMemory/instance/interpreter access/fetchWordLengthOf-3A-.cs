fetchWordLengthOf: objectPointer

	| sz |
	sz _ self sizeBitsOf: objectPointer.
	^ (sz - BaseHeaderSize) >> 2