setX: value
	^self setPointOfView: ((self getPointOfView) at: 1 put: value * 0.01; yourself) duration: rightNow