setY: value
	^self setPointOfView: ((self getPointOfView) at: 2 put: value * 0.01; yourself) duration: rightNow