boundaryStartTime
	^ self timeForEvent: (phrase ifNil: [clause phrases last]) words last events first