setFont
	super setFont.
	"Make a local copy of stop conditions so we don't modify the default"
	stopConditions == DefaultStopConditions 
		ifTrue:[stopConditions _ stopConditions copy].
	stopConditions at: Space asciiValue + 1 put: nil.