setFont
	super setFont.
	stopConditions at: Character space asciiValue + 1 put: nil.