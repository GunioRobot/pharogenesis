hibernate
	"Replace my bitmap with a compactly encoded representation (a ByteArray).  It is vital that BitBlt and any other access to the bitmap (such as writing to a file) not be used when in this state.  Since BitBlt will fail if the bitmap size is wrong (not = bitsSize), we do not allow replacement by a byteArray of the same (or larger) size."
	| compactBits |
	(bits isMemberOf: ByteArray) ifTrue: [^ self  "already compacted"].
	compactBits _ bits compressToByteArray.
	compactBits size < (bits size*4) ifTrue: [bits _ compactBits]