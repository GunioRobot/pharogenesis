primCopyBufferFrom: oldBuffer to: newBuffer
	"Copy the contents of oldBuffer into the (larger) newBuffer"
	<primitive: 'gePrimitiveCopyBuffer'>
	Debug ifTrue:[^BalloonEnginePlugin doPrimitive: 'gePrimitiveCopyBuffer'].
	^self primitiveFailed