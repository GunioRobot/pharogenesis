primInitializeBuffer: buffer
	<primitive: 'gePrimitiveInitializeBuffer'>
	Debug ifTrue:[^BalloonEnginePlugin doPrimitive: 'gePrimitiveInitializeBuffer'].
	^self primitiveFailed