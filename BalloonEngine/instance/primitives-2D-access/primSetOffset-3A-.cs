primSetOffset: point
	<primitive: 'gePrimitiveSetOffset'>
	Debug ifTrue:[^BalloonEnginePlugin doPrimitive: 'gePrimitiveSetOffset'].
	^self primitiveFailed