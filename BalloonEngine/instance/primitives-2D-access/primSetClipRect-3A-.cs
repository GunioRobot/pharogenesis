primSetClipRect: rect
	<primitive: 'gePrimitiveSetClipRect'>
	Debug ifTrue:[^BalloonEnginePlugin doPrimitive: 'gePrimitiveSetClipRect'].
	^self primitiveFailed