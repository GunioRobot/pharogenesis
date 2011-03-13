readInto: aStringOrByteArray startingAt: index
	"Read data into the given String or ByteArray object starting at the given index, and answer the number of bytes read. Does not go past the end of the given String or ByteArray."

	^ self primReadPort: port
		into: aStringOrByteArray
		startingAt: index
		count: (aStringOrByteArray size - index) + 1.
