decompressFromByteArray: byteArray
	| s bitmap size |
	s _ ReadStream on: byteArray.
	size _ self decodeIntFrom: s.
	bitmap _ self new: size.
	bitmap decompress: bitmap fromByteArray: byteArray at: s position+1.
	^ bitmap