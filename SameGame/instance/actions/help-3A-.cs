help: helpState

	helpState
		ifTrue: [self addMorphBack: self helpText]
		ifFalse: [helpText delete]