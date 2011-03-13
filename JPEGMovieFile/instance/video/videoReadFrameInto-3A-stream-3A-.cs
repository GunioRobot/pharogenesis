videoReadFrameInto: aForm stream: aStream
	"Read the next frame into the given 16-bit or 32-bit Form."

	| compressedBytes |
	compressedBytes := self bytesForFrame: currentFrameIndex.
	compressedBytes ifNil: [^ self].
	JPEGReadWriter2 new uncompress: compressedBytes into: aForm.
	currentFrameIndex := (currentFrameIndex + 1) min: (frameOffsets size - 1).
