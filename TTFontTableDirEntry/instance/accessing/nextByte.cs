nextByte

	| value |
	value _ fontData byteAt: offset.
	offset _ offset + 1.
	^value