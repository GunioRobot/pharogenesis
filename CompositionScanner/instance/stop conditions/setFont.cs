setFont
	super setFont.
	stopConditions == DefaultStopConditions 
		ifTrue:[stopConditions _ stopConditions copy].
	stopConditions at: Space asciiValue + 1 put: #space.