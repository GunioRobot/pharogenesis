bytesForFrame: frameIndex
	"Answer a ByteArray containing the encoded bytes for the frame with the given index. Answer nil if the index is out of range or if my file is not open."

	frameIndex < 1 ifTrue: [^ nil].
	frameIndex >= frameOffsets size ifTrue: [^ nil].
	file ifNil: [^ nil].
	file closed ifTrue: [file ensureOpen; binary].
	file position: (frameOffsets at: frameIndex).
	^ file next: (frameOffsets at: frameIndex + 1) - (frameOffsets at: frameIndex)
