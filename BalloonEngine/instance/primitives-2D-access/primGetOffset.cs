primGetOffset
	<primitive: 'gePrimitiveGetOffset'>
	Debug ifTrue:[^BalloonEnginePlugin doPrimitive: 'gePrimitiveGetOffset'].
	^self primitiveFailed