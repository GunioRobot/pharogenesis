readTrackChunk

	| chunkType chunkSize |
	chunkType _ self readChunkType.
	[chunkType = 'MTrk'] whileFalse: [
		self report: 'skipping unexpected chunk type "', chunkType, '"'.
		stream skip: (self readChunkSize).  "skip it"
		chunkType _ (stream next: 4) asString].
	chunkSize _ self readChunkSize.
	chunkSize < 10000000 ifFalse: [
		self error: 'suspiciously large track chunk; this may not be MIDI file'].

	self readTrackContents: chunkSize.
