switchHeadLightStatus
	(headLightStatus = #on)
		ifTrue: [self switchHeadLightOff]
		ifFalse: [self switchHeadLightOn]