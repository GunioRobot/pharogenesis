primGetAALevel
	"Set the AA level"
	<primitive: 'gePrimitiveGetAALevel'>
	Debug ifTrue:[^BalloonEnginePlugin doPrimitive: 'gePrimitiveGetAALevel'].
	^self primitiveFailed