getPenColor
	penColor ifNil: [penColor _ self defaultPenColor].
	^ penColor