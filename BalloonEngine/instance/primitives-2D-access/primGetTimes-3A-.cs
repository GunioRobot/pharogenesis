primGetTimes: statsArray
	<primitive:'gePrimitiveGetTimes'>
	Debug ifTrue:[^BalloonEnginePlugin doPrimitive: 'gePrimitiveGetTimes'].
	^self primitiveFailed