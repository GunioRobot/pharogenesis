nextULong

	| value |
	value _ fontData unsignedLongAt: offset bigEndian: true.
	offset _ offset + 4.
	^value