setZ: value
	^self setPointOfView: ((self getPointOfView) at: 3 put: value * 0.01; yourself) duration: rightNow