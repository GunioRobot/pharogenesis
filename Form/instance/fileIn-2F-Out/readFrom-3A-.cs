readFrom: aFile
	"Reads the receiver from the file in the format:
		depth, extent, offset, bits."
	| offsetX offsetY |
	depth _ aFile next.
	(depth isPowerOfTwo and: [depth between: 1 and: 32])
		ifFalse: [self halt  "invalid depth"].
	width _ aFile nextWord.
	height _ aFile nextWord.
	offsetX  _ aFile nextWord.
	offsetY _ aFile nextWord.
	offsetX > 32767 ifTrue: [offsetX _ offsetX - 65536].
	offsetY > 32767 ifTrue: [offsetY _ offsetY - 65536].
	bits _ Bitmap newFromStream: aFile.
	bits size = self bitsSize ifFalse: [self halt "incompatible bitmap size"].
	^ self