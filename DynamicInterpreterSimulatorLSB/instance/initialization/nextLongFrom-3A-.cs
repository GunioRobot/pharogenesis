nextLongFrom: aStream
	"Read a 32-bit quantity from the given (binary) stream."
	| bytes |
	bytes _ aStream nextInto: (ByteArray new: 4).
	^ Integer
		byte1: (bytes at: 1)
		byte2: (bytes at: 2)
		byte3: (bytes at: 3)
		byte4: (bytes at: 4)