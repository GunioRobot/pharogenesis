setStopConditions
	"Set the font and the stop conditions for the current run."
	
	self setFont.
	textStyle alignment = Justified ifTrue:[
		"Make a local copy of stop conditions so we don't modify the default"
		stopConditions == DefaultStopConditions 
			ifTrue:[stopConditions _ stopConditions copy].
		stopConditions at: Space asciiValue + 1 put: #paddedSpace]