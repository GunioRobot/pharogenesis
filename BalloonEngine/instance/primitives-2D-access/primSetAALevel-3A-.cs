primSetAALevel: level
	"Set the AA level"
	<primitive: 'gePrimitiveSetAALevel'>
	Debug ifTrue:[^BalloonEnginePlugin doPrimitive: 'gePrimitiveSetAALevel'].
	^self primitiveFailed