nextLong

	| value |
	value _ fontData longAt: offset bigEndian: true.
	offset _ offset + 4.
	^value