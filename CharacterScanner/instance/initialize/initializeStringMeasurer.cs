initializeStringMeasurer
	stopConditions := Array new: 258.
	stopConditions 
		at: CrossedX
		put: #crossedX.
	stopConditions 
		at: EndOfRun
		put: #endOfRun