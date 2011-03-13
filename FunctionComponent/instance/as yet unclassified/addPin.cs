addPin 
	| i prev sideLength wasNew |
	wasNew _ self getText = textMorph asText.
	i _ pinSpecs size.
	prev _ pinSpecs last.
	sideLength _ prev pinLoc asInteger odd ifTrue: [self height] ifFalse: [self width].
	pinSpecs _ pinSpecs copyWith:
		(PinSpec new pinName: ('abcdefghi' copyFrom: i to: i) direction: #input
				localReadSelector: nil localWriteSelector: nil
				modelReadSelector: nil modelWriteSelector: nil
				defaultValue: nil pinLoc: prev pinLoc + (8/sideLength) asFloat \\ 4).
	self initFromPinSpecs.
	self addPinFromSpec: pinSpecs last.
	wasNew ifTrue: [self setText: self getText].
	self accept
	