primGetBezierStats: statsArray
	<primitive:'gePrimitiveGetBezierStats'>
	Debug ifTrue:[^BalloonEnginePlugin doPrimitive: 'gePrimitiveGetBezierStats'].
	^self primitiveFailed