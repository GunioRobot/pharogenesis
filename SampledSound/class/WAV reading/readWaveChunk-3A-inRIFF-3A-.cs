readWaveChunk: chunkType inRIFF: stream
	"Search the stream for a format chunk and return its contents"
	| dwLength fourcc |
	"Get to binary and skip 'RIFF'"
	stream reset; binary; skip: 4.
	"Read length of all data"
	dwLength := self next32BitWord: false from: stream.
	"Get RIFF contents type "
	fourcc := self readChunkTypeFrom: stream.
	fourcc = 'WAVE' ifFalse:[^nil]. "We can only read WAVE files here"
	"Search for chunk"
	[fourcc := self readChunkTypeFrom: stream.
	dwLength := self next32BitWord: false from: stream.
	fourcc = chunkType] whileFalse:[
		"Skip chunk - rounded to word boundary"
		stream skip: (dwLength + 1 bitAnd: 16rFFFFFFFE).
		stream atEnd ifTrue:[^'']].
	"Return raw data"
	^stream next: dwLength