setStopConditions
	"Set the font and the stop conditions for the current run."
	
	self setFont.
	stopConditions 
		at: Space asciiValue + 1 
		put: (textStyle alignment = Justified ifTrue: [#paddedSpace])