nextShort

	| value |
	value _ fontData shortAt: offset bigEndian: true.
	offset _ offset + 2.
	^value