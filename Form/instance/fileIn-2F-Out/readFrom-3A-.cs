readFrom: aBinaryStream
	"Reads the receiver from the given binary stream with the format:
		depth, extent, offset, bits."
	| offsetX offsetY |
	depth _ aBinaryStream next.
	(depth isPowerOfTwo and: [depth between: 1 and: 32])
		ifFalse: [self error: 'invalid depth; bad Form file?'].
	width _ aBinaryStream nextWord.
	height _ aBinaryStream nextWord.
	offsetX  _ aBinaryStream nextWord.
	offsetY _ aBinaryStream nextWord.
	offsetX > 32767 ifTrue: [offsetX _ offsetX - 65536].
	offsetY > 32767 ifTrue: [offsetY _ offsetY - 65536].
	bits _ Bitmap newFromStream: aBinaryStream.
	bits size = self bitsSize ifFalse: [self error: 'wrong bitmap size; bad Form file?'].
	^ self
