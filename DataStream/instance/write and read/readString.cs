readString

	| str |
	byteStream ascii.
	str _ byteStream nextString.
	byteStream binary.
	^ str
