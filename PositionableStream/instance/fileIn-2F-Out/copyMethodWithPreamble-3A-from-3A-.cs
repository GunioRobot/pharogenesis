copyMethodWithPreamble: preamble from: aStream
	| newFilePosition |
	"First copy the preamble if any."
	self copyPreamble: preamble from: aStream.

	"Then copy the method chunk"
	newFilePosition _ self position.
	self copyMethodChunkFrom: aStream.
	self nextChunkPut: ' '.
	^ newFilePosition