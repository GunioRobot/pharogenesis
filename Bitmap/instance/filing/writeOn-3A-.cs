writeOn: aStream 
	"Store the array of bits onto the argument, aStream.  Use a simple run-coded compression of the receiver into a byteArray:
		First 4 bytes are the size of the original Bitmap *negated*.
		This is followed by a number of runs...
		[0 means end of runs]
		[n = 1..127] [(n+3) copies of next byte]
		[n = 128..191] [(n-127) next bytes as is]
		[n = 192..255] [(n-190) copies of next 4 bytes].
	Difference from compressToByteArray is that first word is size negated here."
	"Optimization: compress in memory, then store on aStream; 30% faster for FileStreams"

	| s |
	s _ WriteStream on: (ByteArray new: self size * 4).
	self compressToStream: s.
	aStream nextInt32Put: self size negated.
	aStream nextPutAll: s contents.
