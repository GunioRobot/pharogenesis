nextBufferOrNil
	"Answer the next input buffer or nil if no buffer is available."

	| result |
	mutex ifNil: [^ nil].  "not recording"
	mutex critical: [
		recordedBuffers size > 0
			ifTrue: [result := recordedBuffers removeFirst]
			ifFalse: [result := nil]].
	^ result
