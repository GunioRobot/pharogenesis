unhibernate
	"If my bitmap has been compressed into a ByteArray,
	then expand it now, and return true."

	(bits isMemberOf: ByteArray)
		ifTrue: [bits _ Bitmap decompressFromByteArray: bits. ^ true].
	^ false