primInitializeProcessing
	"Initialize processing in the GE.
	Create the active edge table and sort it."
	<primitive: 'gePrimitiveInitializeProcessing'>
	Debug ifTrue:[^BalloonEnginePlugin doPrimitive: 'gePrimitiveInitializeProcessing'].
	^self primitiveFailed