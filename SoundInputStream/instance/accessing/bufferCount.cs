bufferCount
	"Answer the number of sound buffers that have been queued."

	| n |
	mutex ifNil: [^ 0].  "not recording"
	mutex critical: [n _ recordedBuffers size].
	^ n
