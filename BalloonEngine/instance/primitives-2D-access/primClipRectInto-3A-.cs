primClipRectInto: rect
	<primitive: 'gePrimitiveGetClipRect'>
	Debug ifTrue:[^BalloonEnginePlugin doPrimitive:'gePrimitiveGetClipRect'].
	^self primitiveFailed