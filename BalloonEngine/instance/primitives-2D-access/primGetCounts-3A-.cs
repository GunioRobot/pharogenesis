primGetCounts: statsArray
	<primitive:'gePrimitiveGetCounts'>
	Debug ifTrue:[^BalloonEnginePlugin doPrimitive: 'gePrimitiveGetCounts'].
	^self primitiveFailed