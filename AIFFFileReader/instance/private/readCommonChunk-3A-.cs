readCommonChunk: chunkSize
	"Read a COMM chunk. All AIFF files have exactly one chunk of this type."

	| compressionType |
	channelCount _ in nextNumber: 2.
	frameCount _ in nextNumber: 4.
	bitsPerSample _ in nextNumber: 2.
	samplingRate _ self readExtendedFloat.
	chunkSize > 18 ifTrue: [
		fileType = 'AIFF'
			ifTrue: [self error: 'unexpectedly long COMM chunk size for AIFF file'].
		compressionType _ (in next: 4) asString.
		compressionType = 'NONE' ifFalse: [self error: 'cannot read compressed AIFF files'].
		in skip: (chunkSize - 22)].  "skip the reminder of AIFF-C style chunk"
