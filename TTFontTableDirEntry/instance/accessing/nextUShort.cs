nextUShort

	| value |
	value _ fontData unsignedShortAt: offset bigEndian: true.
	offset _ offset + 2.
	^value