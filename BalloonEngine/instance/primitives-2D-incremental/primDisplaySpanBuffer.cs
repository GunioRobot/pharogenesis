primDisplaySpanBuffer
	"Display the current scan line if necessary"
	<primitive: 'gePrimitiveDisplaySpanBuffer'>
	Debug ifTrue:[^BalloonEnginePlugin doPrimitive: 'gePrimitiveDisplaySpanBuffer'].
	^self primitiveFailed