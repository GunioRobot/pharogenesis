getPenSize
	penSize ifNil: [penSize _ self defaultPenSize].
	^ penSize