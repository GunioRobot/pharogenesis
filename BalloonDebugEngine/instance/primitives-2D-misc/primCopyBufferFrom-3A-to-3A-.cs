primCopyBufferFrom: oldBuffer to: newBuffer
	"Copy the contents of oldBuffer into the (larger) newBuffer"
	^BalloonEnginePlugin doPrimitive: 'gePrimitiveCopyBuffer'